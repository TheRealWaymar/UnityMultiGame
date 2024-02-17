using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using Unity.Netcode;

public class PlayerText : MonoBehaviour
{
    public TMP_Text playerText;
    public GameObject[] playerCount;
    
    // Update is called once per frame
    void Update()
    {
        playerCount = GameObject.FindGameObjectsWithTag("Player");
        int count = 1;
        foreach (GameObject player in playerCount)
        {
           player.GetComponentInChildren<TMP_Text>().text = "Player " + count;
           count++;
        }
    }
}
