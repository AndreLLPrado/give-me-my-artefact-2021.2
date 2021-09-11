using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class PlayerMoviment : NetworkBehaviour
{
    CharacterController cc;
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
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        move.y = Input.GetAxis("Jump");
        //if (move.y < 1f)
        //{
        //    move.y -= 1f;
        //}
        
        move = Vector3.ClampMagnitude(move, 1f);

        Debug.Log(move.y.ToString());

        //cc.SimpleMove(move * 5f);
        cc.Move(move * 5f * Time.deltaTime);
    }
}
