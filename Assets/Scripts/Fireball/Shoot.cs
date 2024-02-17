using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class Shoot : NetworkBehaviour
{
    public GameObject fireball;
    public Transform shootTransform;

    void Update()
    {
        if (!IsOwner) return;
        if(Input.GetKeyDown(KeyCode.F))
        {
            ShootServerRpc();
        }
    }

    [ServerRpc]
    private void ShootServerRpc()
    {
        GameObject go = Instantiate(fireball, shootTransform.position, shootTransform.rotation);
            go.GetComponent<NetworkObject>().Spawn();
    }
}
