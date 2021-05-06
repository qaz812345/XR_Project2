using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.IO;

public class PlayerCreator : MonoBehaviourPunCallbacks
{
    public enum ModelGender{
        Male = 0,
        Female = 1
    }

    [Tooltip( "Decide the gender of your customize model" )]
    public ModelGender modelGender;

    //The local user's player's gameobject
    private GameObject myPlayer;
    private string jsonObject;

    public override void OnJoinedRoom(){
        Debug.Log("Join Room");
        base.OnJoinedRoom();

        //Instantiate the player
        myPlayer = PhotonNetwork.Instantiate("Player Prefab", Vector3.zero, Quaternion.identity);
        createPlayerModel(myPlayer);
    }

    public override void OnLeftRoom(){
        Debug.Log("Left Room");
        PhotonNetwork.Destroy(myPlayer);
        base.OnLeftRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer){
        Debug.Log("A new player enter room.");
        base.OnPlayerEnteredRoom(newPlayer);
        createPlayerModel(myPlayer);
    }

    private void createPlayerModel(GameObject player){
        PlayerModelCreator modelCreator = player.GetComponent<PlayerModelCreator>();
        if(this.jsonObject == null)
            this.jsonObject = getCustomizeModelJson(modelGender);
        modelCreator.createCustomizeModel(this.jsonObject, modelGender);
    }

    private string getCustomizeModelJson(ModelGender gender){
        string genderName = "Male";
        if(gender == ModelGender.Female) genderName = "Female";
        var dataPath = Application.dataPath;
        var folderPath = string.Format("{0}/{1}", dataPath, "CharactersData");
        var filePath = string.Format("{0}/characterData_{1}.json", folderPath, genderName);
        if (File.Exists(filePath))
        {
            string jsonObject = File.ReadAllText(filePath);
            return jsonObject;
        }
        return "";
    }
}
