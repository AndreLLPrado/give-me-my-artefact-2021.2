using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.NetworkVariable;
using MLAPI.Transports;
using MLAPI.Messaging;

public class gameManagerScript : NetworkBehaviour
{
    List<GameObject> players = new List<GameObject>();
    Stack<ulong> playerID = new Stack<ulong>();
    NetworkVariableInt nPlayers;

    void Awake()
    {
        nPlayers.Value = 0;
    }
    private void Start()
    {
        playerID = null;
    }

    [ServerRpc]
    private void WaitingPlayerServerRpc()
    {
        playerID.Push(NetworkManager.Singleton.LocalClientId);
        nPlayers.Value++;

        if(nPlayers.Value >= 2)
        {
            RandomFormsServerRpc();
        }
    }

    [ServerRpc]
    private void RandomFormsServerRpc()
    {
        Stack<ulong> aux = new Stack<ulong>();

        int result = (int)Random.Range(1, 2);

        if(result == 1)
        {
            //wizzard form
        }
        else if(result == 2)
        {
            //cat form
        }
        else
        {
            //invalid result
        }
    }
}
