using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// display the color of the spray in UI


public class GetSprayColor : MonoBehaviour
{
    public GameObject player; 
    GameObject x; //the spray
    int count; //amount of sprays in inventory
    Color32 color;
    public int spray; //the order in player's inventory
    public int toolLimit;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count = player.GetComponent<Inventory_player>().inventory.itemList.Count;
        if(count == 0 || spray >= count)
        {
            //if no spray than transparent
            this.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        }

        //get color of the spray
        if (count > 0 && count > spray)
        {
            x = player.GetComponent<Inventory_player>().inventory.itemList[spray];
            //Debug.Log(count);
            if (x.transform.Find("Particles (Optimized)") != null)
            {
                foreach (PaintIn3D.P3dPaintSphere ph in x.transform.Find("Particles (Optimized)").GetComponents<PaintIn3D.P3dPaintSphere>())
                {
                    if (ph.Group == 0)
                    {
                        //Debug.Log(ph.Color.r);
                        color = ph.Color;
                        this.GetComponent<Image>().color = color;
                    }
                }
            }
        }
    }
}


