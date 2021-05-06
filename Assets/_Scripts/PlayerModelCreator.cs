using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using AdvancedCustomizableSystem;
using RootMotion.FinalIK;

public class PlayerModelCreator : MonoBehaviour
{
    public GameObject MaleModelPrefab;
    public GameObject FemaleModelPrefab;

    [Tooltip("IK target")]
    public Transform headTarget;
    public Transform leftHandTarget;
    public Transform rightHandTarget;
    private GameObject playerModel;

    public void createCustomizeModel(string jsonObject, PlayerCreator.ModelGender gender){
        GetComponent<PhotonView>().RPC("_createCustomizeModel", RpcTarget.All, jsonObject, gender);
    }

    [PunRPC]
    private void _createCustomizeModel(string jsonObject, PlayerCreator.ModelGender gender){
        if(playerModel != null) return;
        //Create the customize model
        if(gender == PlayerCreator.ModelGender.Male){
            playerModel = GameObject.Instantiate(MaleModelPrefab, Vector3.zero, Quaternion.identity);
        }
        else{
            playerModel = GameObject.Instantiate(FemaleModelPrefab, Vector3.zero, Quaternion.identity);
        }
        playerModel.transform.parent = this.transform;

        //Set up the custmoize look
        CharacterCustomizationSetup characterCustomizationSetup = CharacterCustomizationSetup.DeserializeFromJson(jsonObject);
        playerModel.GetComponent<CharacterCustomization>().SetCharacterSetup(characterCustomizationSetup);

        //Set up the IK
        VRIK ik = playerModel.GetComponent<VRIK>();
        ik.solver.spine.headTarget = this.headTarget;
        ik.solver.leftArm.target = this.leftHandTarget;
        ik.solver.rightArm.target = this.rightHandTarget;
    }
}
