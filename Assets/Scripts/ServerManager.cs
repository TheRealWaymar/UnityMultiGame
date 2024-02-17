using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ServerManager : MonoBehaviour
{
    public PlayerStatus setPlayerStatus;
    public GameObject lobbyUI;
    public void startHost()
    {
        NetworkManager.Singleton.StartHost();
        //Changes Player Status Text from PlayerStatus Script
        setPlayerStatus.setStatusHost();
        lobbyUI.SetActive(false);
    }
    public void startServer()
    {
        NetworkManager.Singleton.StartServer();
        lobbyUI.SetActive(false);
    }
    public void startClient()
    {
        NetworkManager.Singleton.StartClient();
        setPlayerStatus.setStatusClient();
        lobbyUI.SetActive(false);
    }
}
