using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI.NetworkVariable;
using MLAPI;
using UnityEngine.UI;
using MLAPI.NetworkVariable;

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

    private ulong playerID;
    void Start()
    {
        playerID = NetworkManager.Singleton.LocalClientId;

        asCat = false;
        asWizzard = false;

        if (IsLocalPlayer)
        {
            nickTxt.Value = GameObject.Find("GameCanvas").GetComponent<MenuScript>().inputNickname.text;
        }
            nick.text = nickTxt.Value;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLocalPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && !asWizzard)
            {
                setPlayerAsWizzard();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && !asCat)
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
        gameObject.GetComponent<PlayerMoviment>().playerSpeed *= 2f;

        asCat = true;
        asWizzard = false;
    }

    public void setPlayerAsWizzard()
    {
        gameObject.GetComponentInChildren<MeshRenderer>().sharedMaterial = color1;
        //gameObject.GetComponentInChildren<MeshRenderer>().sharedMaterial = color1.Value;
        //gameObject.GetComponent<PlayerMoviment>().changeColor(color2.Value);
        gameObject.GetComponent<PlayerMoviment>().playerSpeed = 5f;

        asCat = false;
        asWizzard = true;
    }
}
