using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI.NetworkVariable;
using MLAPI;
using UnityEngine.UI;

public class playerChangesScript : NetworkBehaviour
{
    // Start is called before the first frame update
    //public NetworkVariable<Material> color1;
    //public NetworkVariable<Material> color2;

    public Material color1;
    public Material color2;

    public bool asCat;
    public bool asWizzard;

    
    public Text nick;
    public NetworkVariableString nickTxt;
    //public NetworkVariable<Text> nick;

    public NetworkVariableBool changeWizzard;
    public NetworkVariableBool changeCat;

    //bool changeWizzard;
    //bool changeCat;

    private ulong playerID;
    void Start()
    {
        playerID = NetworkManager.Singleton.LocalClientId;

        asCat = false;
        asWizzard = false;

        if (IsLocalPlayer)
        {
            nickTxt.Value = GameObject.Find("GameCanvas").GetComponent<MenuScript>().inputNickname.text;

            if(nickTxt.Value.Length <= 0)
            {
                nickTxt.Value = playerID.ToString();
            }
        }
            nick.text = nickTxt.Value;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLocalPlayer)
        {
            //if (Input.GetKeyDown(KeyCode.Alpha1))
            //{
            //    changeWizzard.Value = true;
            //    changeCat.Value = false;
            //}
            //else if (Input.GetKeyDown(KeyCode.Alpha2))
            //{
            //    changeCat.Value = true;
            //    changeWizzard.Value = false;
            //}

            GetPlayerForm();

            //asWizzard = changeWizzard.Value;
            //asCat = changeCat.Value;

            if (asWizzard || changeWizzard.Value)
            {
                setPlayerAsWizzard();
            }

            if (asCat || changeCat.Value)
            {
                setPlayerAsCat();
            }
        }
    }

    public void setPlayerAsCat()
    {
        gameObject.GetComponentInChildren<MeshRenderer>().sharedMaterial = color2;
        //gameObject.GetComponentInChildren<MeshRenderer>().sharedMaterial = color2.Value;
        //gameObject.GetComponent<PlayerMoviment>().changeColor(color1.Value);
        gameObject.GetComponent<PlayerMoviment>().playerSpeed = 10f;

        //asCat = true;
        //asWizzard = false;
    }

    public void setPlayerAsWizzard()
    {
        gameObject.GetComponentInChildren<MeshRenderer>().sharedMaterial = color1;
        //gameObject.GetComponentInChildren<MeshRenderer>().sharedMaterial = color1.Value;
        //gameObject.GetComponent<PlayerMoviment>().changeColor(color2.Value);
        gameObject.GetComponent<PlayerMoviment>().playerSpeed = 5f;

        //asCat = false;
        //asWizzard = true;
    }

    public void GetPlayerForm()
    {
        //asWizzard = GameObject.Find("GameCanvas").GetComponent<MenuScript>().cWizzard;
        //asCat = GameObject.Find("GameCanvas").GetComponent<MenuScript>().cCat;

        changeWizzard.Value = GameObject.Find("GameCanvas").GetComponent<MenuScript>().cWizzard;
        changeCat.Value = GameObject.Find("GameCanvas").GetComponent<MenuScript>().cCat;
    }
}
