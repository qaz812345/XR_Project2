using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableChangeOpacity : MonoBehaviour
{
    int count;
    public GameObject player;
    public int spray; //order of spray
    public GameObject opacities; // the entirety of the buttons that change opacity
    public GameObject decal;
    bool active;


    // check if there is spray
    public void checkSpray()
    {
        count = player.GetComponent<Inventory_player>().inventory.itemList.Count;
        active = opacities.activeSelf;


        Debug.Log("進入checkSpray"); 
        if (count > 0)
        {
            if (count < spray)
            {

                Debug.Log(" if (count < spray)");
                opacities.SetActive(false);
            }
            else
            {

                if (active)
                {

                    Debug.Log("if (active)");
                    opacities.SetActive(false);
                    decal.SetActive(true);
                }
                else
                {
                    Debug.Log("sprayyyyyyyy");
                    opacities.SetActive(true);
                    decal.SetActive(false);
                }
            }
        }
        
        
    }


    void Start()
    {

        active = false;
    }

    void Update()
    {
        
    } 

}
