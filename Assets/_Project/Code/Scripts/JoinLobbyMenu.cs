using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class JoinLobbyMenu : MonoBehaviour
{
    [SerializeField]
    private NetworkManagerLobby networkManager = null;

    [Header("UI")]

    [SerializeField] private GameObject landingPagePanel = null;
    [SerializeField] private InputField ipAdressInputField = null;
    [SerializeField] private Button joinButton = null;

    public void JoinLobby()
    {
        string ipAdress = ipAdressInputField.text;

        networkManager.networkAddress = ipAdress;
        networkManager.StartClient();

        joinButton.interactable = false;
    }

    private void HandleClientConnected()
    {
        joinButton.interactable = true;

        gameObject.SetActive(false);
        landingPagePanel.SetActive(false);
    }

    private void HandleClientDisconnected()
    {
        joinButton.interactable = true;   
    }

    private void OnEnable()
    {
        NetworkManagerLobby.OnClientConnected += HandleClientConnected;
        NetworkManagerLobby.OnClientDisconnected += HandleClientDisconnected;
    }

    private void OnDisable()
    {
        NetworkManagerLobby.OnClientConnected -= HandleClientConnected;
        NetworkManagerLobby.OnClientDisconnected += HandleClientDisconnected;

    }
}

