using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class MenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject userNameScreen, connectScreen;

    [SerializeField]
    private GameObject createUserNameButton;

    [SerializeField]
    private InputField userNameInput, createRoomInput, joinRommInput;

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    /// <summary>
    /// 
    /// </summary>
    public override void OnConnectedToMaster()
    {
        Debug.Log("__________Conectando al servidor__________");
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    /// <summary>
    /// 
    /// </summary>
    public override void OnJoinedLobby()
    {
        Debug.Log("__________Conectando al Lobby_____________");
        userNameScreen.SetActive(true); 
    }

    /// <summary>
    /// 
    /// </summary>
    public override void OnJoinedRoom()
    {
        //Aqui mandamos llamar la escena del juego
        PhotonNetwork.LoadLevel(1);
    }


    #region UIMethots
    /// <summary>
    /// 
    /// </summary>
    public void OnClick_CreateNameButton()
    {
        PhotonNetwork.NickName = userNameInput.text;
        userNameScreen.SetActive(false);
        connectScreen.SetActive(true);
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnNameInputfield_Changed()
    {
        if (userNameInput.text.Length >=2)
        {
            createUserNameButton.SetActive(true);
        }
        else
        {
            createUserNameButton.SetActive(false); 
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnClick_JoinRoom()
    {
        RoomOptions room = new RoomOptions();
        room.MaxPlayers = 4;

        PhotonNetwork.JoinOrCreateRoom(joinRommInput.text, room, TypedLobby.Default);
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnClick_CreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoomInput.text, new RoomOptions { MaxPlayers = 4 }, null);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cause"></param>
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("__________Se ha desconectado el servidor a causa de {0}__________", cause);
    }
    #endregion
}
