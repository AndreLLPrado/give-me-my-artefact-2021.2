using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class PlayerMoviment : NetworkBehaviour
{
    CharacterController cc;
    Vector3 move;
    public float jumpSpeed;
    public float playerSpeed;
    public float rotSpeed;
    public float gravity;
    void Start()
    {
        cc = GetComponent<CharacterController>();
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
}
