using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;

public class VRMenuShow : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    public GameObject menu;
    public SteamVR_Action_Boolean menuClick;
    private bool isShowing = false;

    void Update()
    {
        if (menuClick.stateUp)
        {
            isShowing = !isShowing;
            menu.SetActive(isShowing);
        }
        if (isShowing == true)
        {
            OpenLaserPointer();
            //Debug.Log("Menu Show");
        }
        else
        {
            CloseLaserPointer();
            //Debug.Log("Menu Hide");
        }
            
    }

    public void OpenLaserPointer()
    {
        laserPointer.enabled = true;
    }

    public void CloseLaserPointer()
    {
        laserPointer.enabled = false;
        //laserPointer.pointer.transform.localScale = new Vector3(0, 0, 0);
    }

}
