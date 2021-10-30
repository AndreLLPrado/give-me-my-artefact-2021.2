using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Collections;
using MLAPI.NetworkVariable;

public class playerColorManager : NetworkBehaviour
{

    public void SelectPlayer()
    {
        ulong localClientId = NetworkManager.Singleton.LocalClientId;

        //if(!NetworkManager.Singleton.ConnectedClients.TryGetValue(localClientId, out NetworkClient networkClient))
        //{
        //    return;
        //}
    }
}
