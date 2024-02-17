using System;
using Unity.Netcode;
using UnityEngine;

public class NetworkTransformTest : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        if (!IsServer && IsOwner) //Only send an RPC to the server on the client that owns the NetworkObject that owns this NetworkBehaviour instance
        {
            
        }
    }
    void Update()
    {
        if (IsOwner)
        {
            UpdateClient();   
        }
    }

    void UpdateClient()
    {
        if ((Input.GetKey(KeyCode.W)))
        {
            transform.position += transform.forward * Time.deltaTime;
        }
        if ((Input.GetKey(KeyCode.S)))
        {
            transform.position -= transform.forward * Time.deltaTime;
        }
        if ((Input.GetKey(KeyCode.D)))
        {
            transform.position += transform.right * Time.deltaTime;
        }
        if ((Input.GetKey(KeyCode.A)))
        {
            transform.position -= transform.right * Time.deltaTime;
        }
    }
}
