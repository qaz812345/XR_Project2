using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class IKTargetControl : MonoBehaviour
{
    public Transform HMDTarget;
    public Transform leftHandTarget;
    public Transform rightHandTarget;

    // Update is called once per frame
    void Update()
    {
        //If the current Player GameObject is the local one (If it is created from others, it should be synchornized via Photon)
        if(this.GetComponent<PhotonView>().IsMine){
            //Sync the devices' transform to the IK target
            if(DeviceManager.Instance.HMD != null && DeviceManager.Instance.HMD.gameObject.activeSelf){
                mapTransform(HMDTarget, DeviceManager.Instance.HMD);
            }

            if(DeviceManager.Instance.leftHand != null && DeviceManager.Instance.leftHand.gameObject.activeSelf){
                mapTransform(leftHandTarget, DeviceManager.Instance.leftHand);
            }
            else{
                setRelativeHandTrasnform(HMDTarget, leftHandTarget, new Vector3(-0.2f, -0.65f, 0));
            }
            
            if(DeviceManager.Instance.rightHand != null && DeviceManager.Instance.rightHand.gameObject.activeSelf){
                mapTransform(rightHandTarget, DeviceManager.Instance.rightHand);
            }
            else{
                setRelativeHandTrasnform(HMDTarget, rightHandTarget, new Vector3(0.2f, -0.65f, 0));
            }  
        }
    }

    private void mapTransform(Transform IKtarget, Transform device){
        IKtarget.position = device.position;
        IKtarget.rotation = device.rotation;
    }

    private void setRelativeHandTrasnform(Transform head, Transform hand, Vector3 relativePos){
        hand.position = head.TransformPoint(relativePos);
        hand.localEulerAngles = new Vector3(180, 0, 0);
    }
}
