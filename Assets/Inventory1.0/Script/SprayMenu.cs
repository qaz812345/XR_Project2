using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;
using Valve.VR;

public class SprayMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Spray_Menu;
    public GameObject decal;
    public GameObject MusicMenu;
    bool state;
    GameObject x;
    GameObject y;
    GameObject Hand;

    public void musicMenu()
    
    {
        if (Spray_Menu.activeSelf)
        {
            MusicMenu.SetActive(true);
            Spray_Menu.SetActive(false);
        }
        else
        {
            MusicMenu.SetActive(false);
            Spray_Menu.SetActive(true);
        }
            
    }


    public void Menu()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (state)
            {
                Spray_Menu.SetActive(false);
            }
            else
                Spray_Menu.SetActive(true);
        }
    }

    public void MenuVR()
    {
        
        if (ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Grip))
        {
            
            if (state)
            {
                Spray_Menu.SetActive(false);
                
                Hand.GetComponent<Valve.VR.Extras.SteamVR_LaserPointer>().enabled = false;
                Debug.Log("Laser disabled");
                GameObject test = FindGameObjectInChildWithTag(GameObject.FindGameObjectWithTag("RightHand"), "HVLP");
                GameObject decalTest = FindGameObjectInChildWithTag(GameObject.FindGameObjectWithTag("RightHand"), "Decal");
                if (test == null && decalTest == null && y == null)
                    x.SetActive(true);
                if (test == null && decalTest == null && x == null)
                    y.SetActive(true);

            }
            else
            {
                GameObject go = FindGameObjectInChildWithTag(GameObject.FindGameObjectWithTag("RightHand"), "HVLP");
                GameObject de = FindGameObjectInChildWithTag(GameObject.FindGameObjectWithTag("RightHand"), "Decal");
                x = go;
                y = de;
                Spray_Menu.SetActive(true);
                if (go != null)
                    go.SetActive(false);
                if (de != null)
                    y.SetActive(false);
                Debug.Log("Laser");
                Hand.GetComponent<Valve.VR.Extras.SteamVR_LaserPointer>().enabled = true;
                

            }
                
        }
    }
    

    public static GameObject FindGameObjectInChildWithTag(GameObject parent, string tag)
    {
        Transform t = parent.transform;

        for (int i = 0; i < t.childCount; i++)
        {
            if (t.GetChild(i).gameObject.tag == tag && t.GetChild(i).gameObject.activeSelf)
            {
                return t.GetChild(i).gameObject;
            }

        }

        return null;
    }

    void Start()
    {
        Hand = GameObject.FindGameObjectWithTag("RightHand");

    }

    // Update is called once per frame
    void Update()
    {
        state = Spray_Menu.activeSelf;
        Menu();
        MenuVR();
    }
}
