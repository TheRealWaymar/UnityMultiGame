using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Components;
using TMPro;

public class PlayerStatus : MonoBehaviour
{
    public TextMeshProUGUI playerStatus;
    public void setStatusHost()
    {
        playerStatus.text = "Player Connected As Host";
    }
    public void setStatusClient()
    {
        playerStatus.text = "Player Connected As Client";
    }
     
}
