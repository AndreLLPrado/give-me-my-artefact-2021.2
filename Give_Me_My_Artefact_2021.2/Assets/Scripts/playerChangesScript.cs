using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI.NetworkVariable;

public class playerChangesScript : MonoBehaviour
{
    // Start is called before the first frame update
    public NetworkVariable<Material> color1;
    public NetworkVariable<Material> color2;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                //gameObject.GetComponentInChildren<MeshRenderer>().sharedMaterial = color1.Value;
                gameObject.GetComponent<PlayerMoviment>().changeColor(color1.Value);
                gameObject.GetComponent<PlayerMoviment>().playerSpeed = 5f;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                //gameObject.GetComponentInChildren<MeshRenderer>().sharedMaterial = color2.Value;
                gameObject.GetComponent<PlayerMoviment>().changeColor(color2.Value);
                gameObject.GetComponent<PlayerMoviment>().playerSpeed *= 2f;
            }
    }
}
