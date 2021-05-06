using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipDecal : MonoBehaviour
{
    public GameObject player;
    public GameObject decal;

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

    public void equipDecal()
    {
        GameObject x = FindGameObjectInChildWithTag(GameObject.FindGameObjectWithTag("RightHand"), "Decal");
        if(x == null)
            decal.SetActive(true);
        else
        {
            x.SetActive(false);
            decal.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
