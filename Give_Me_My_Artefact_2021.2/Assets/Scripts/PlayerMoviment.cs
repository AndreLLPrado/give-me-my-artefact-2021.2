using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.NetworkVariable;

public class PlayerMoviment : NetworkBehaviour
{
    CharacterController cc;
    Vector3 move;
    public float jumpSpeed;
    public float playerSpeed;
    public float rotSpeed;
    public float gravity;

    public Material color;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        changeColor(color);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLocalPlayer)
        {
            MovePlayer();
        }

    }

    void MovePlayer()
    {
        if (cc.isGrounded)
        {
            move = new Vector3(0, 0, Input.GetAxis("Vertical"));
            move = transform.TransformDirection(move);
            move *= playerSpeed;
            if (Input.GetButton("Jump"))
            {
                move.y = jumpSpeed;
            }
        }
        move.y -= gravity * Time.deltaTime;
        
        cc.Move(move * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime, 0);
    }

    public void changeColor(Material c)
    {
        if (IsLocalPlayer)
        {
            GetComponentInChildren<MeshRenderer>().sharedMaterial = c;
        }
        
    }
}
