using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        ConnectToServer();
    }

    private void ConnectToServer(){
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connect to Server...");
    }
    
    public override void OnConnectedToMaster(){
        Debug.Log("Connect to Server.");
        base.OnConnectedToMaster();
        //Join a Room if connect to server
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom("Room", roomOptions, TypedLobby.Default);
    }
}
