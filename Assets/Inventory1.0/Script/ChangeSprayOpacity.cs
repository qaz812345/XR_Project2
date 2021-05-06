using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprayOpacity : MonoBehaviour
{
    public GameObject player;
    public GameObject opacities;
    GameObject x;
    public float opacity; //the desired opacity
    public int spray; //the order of the spray in the inventory


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

    public void changeOpacity()
    {
        x = player.GetComponent<Inventory_player>().inventory.itemList[spray];
        foreach (PaintIn3D.P3dPaintSphere ph in x.transform.Find("Particles (Optimized)").GetComponents<PaintIn3D.P3dPaintSphere>())
        {
            if (ph.Group == 0)
            {
                ph.Opacity = opacity;
                //Debug.Log(ph.Opacity);
            }
        }



    } 

    public void equipEraser()
    {
        Debug.Log("errrrrrrraser");
        player.SetActive(true);
        player.transform.position = GameObject.FindGameObjectWithTag("RightHand").transform.position;
        player.transform.rotation = GameObject.FindGameObjectWithTag("RightHand").transform.rotation;
        player.transform.localEulerAngles = new Vector3(72.0f, 0.0f, 0.0f);
    }

    public void equipSpray()
    {
        x = player.GetComponent<Inventory_player>().inventory.itemList[spray];
        foreach(GameObject i in player.GetComponent<Inventory_player>().inventory.itemList)
        {
            if(i.activeSelf)
            {
                i.SetActive(false);
            }
        }
        GameObject go = FindGameObjectInChildWithTag(GameObject.FindGameObjectWithTag("RightHand"), "HVLP");
        if(go != null)
            go.SetActive(false);
        x.SetActive(true);
        x.GetComponent<MeshCollider>().enabled = false;
        opacities.SetActive(false);

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
