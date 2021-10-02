using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Transports.UNET;
using UnityEngine.UI;
using System;

public class MenuScript : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject timerTextObj;

    public InputField inputField;


    private void Start()
    {
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
        callBack(true, null, approve, new Vector3(0, 10, 0), Quaternion.identity);
    }

    public void Host()
    {
        NetworkManager.Singleton.StartHost();
        menuPanel.SetActive(false);
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
        NetworkManager.Singleton.StartClient();
        menuPanel.SetActive(false);
        //timerTextObj.SetActive(true);
    }
}
