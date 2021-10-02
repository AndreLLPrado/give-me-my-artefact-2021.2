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

    public Material color1;
    public Material color2;
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

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                gameObject.GetComponentInChildren<MeshRenderer>().sharedMaterial = color1;
                playerSpeed = 5f;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                gameObject.GetComponentInChildren<MeshRenderer>().sharedMaterial = color2;
                playerSpeed *= 2;
            }
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
