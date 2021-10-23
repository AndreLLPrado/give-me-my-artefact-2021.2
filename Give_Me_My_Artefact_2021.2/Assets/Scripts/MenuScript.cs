using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Transports.UNET;
using MLAPI.NetworkVariable;
using UnityEngine.UI;
using System;

public class MenuScript : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject timerTextObj;
    public GameObject timerButton;
    public GameObject wizzardButton;
    public GameObject catButton;

    public InputField inputField;
    public InputField inputNickname;

    //public NetworkVariableBool cWizzard;
    //public NetworkVariableBool cCat;

    public bool cWizzard;
    public bool cCat;

    private void Start()
    {
        ActiveWithStart(false, false, false, true);
        NetworkManager.Singleton.ConnectionApprovalCallback += approvalCheck;
    }

    private void approvalCheck(byte[] conectionData, ulong clientID, NetworkManager.ConnectionApprovedDelegate callBack)
    {
        bool approve = false;

        string password = System.Text.Encoding.ASCII.GetString(conectionData);
        if(password == "mygame")
        {
            approve = true;
        }
        Debug.Log($"Approval: {approve}");

        if(inputNickname.text.Length <= 0)
        {
            inputNickname.text = "Player";
        }

        callBack(true, null, approve, new Vector3(0, 10, 0), Quaternion.identity);
    }

    public void Host()
    {
        ActiveWithStart(true, true, true, false);
        NetworkManager.Singleton.StartHost();
        //menuPanel.SetActive(false);
        //timerTextObj.SetActive(true);
    }

    public void Join()
    {
        if(inputField.text.Length <= 0)
        {
            NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = "127.0.0.1";
        }
        else
        {
            NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = inputField.text;
        }
        NetworkManager.Singleton.NetworkConfig.ConnectionData = System.Text.Encoding.ASCII.GetBytes("mygame");
        ActiveWithStart(false, true, true,false);
        NetworkManager.Singleton.StartClient();

        //menuPanel.SetActive(false);
        //timerTextObj.SetActive(true);
    }

    public void ChangePlayerToWizzard()
    {
        cWizzard = true;
        cCat = false;
    }

    public void ChangePlayerToCat()
    {
        cWizzard = false;
        cCat = true;
    }

    void ActiveWithStart(bool bTimer, bool timer, bool playerButtons, bool menu)
    {
        
        menuPanel.SetActive(menu);
        timerButton.SetActive(bTimer);
        timerTextObj.SetActive(timer);
        wizzardButton.SetActive(playerButtons);
        catButton.SetActive(playerButtons);
    }
}
