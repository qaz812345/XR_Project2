using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkPlayerCreator : MonoBehaviourPunCallbacks
{
    private GameObject myPlayer;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        myPlayer = PhotonNetwork.Instantiate("NetworkPlayer", Vector3.zero, Quaternion.identity);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(myPlayer);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A new player enter room.");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
