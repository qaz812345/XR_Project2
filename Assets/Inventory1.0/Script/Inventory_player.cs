using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HTC.UnityPlugin.Vive;
using Valve.VR;

public class Inventory_player : MonoBehaviour
{
    public int toolLimit = 3;
    public int current = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Drop();
    }

    public Inventory inventory;
    // instantiate inventory
    private void Awake()
    {

        inventory = new Inventory();
    }

    //clear list then drop them 
    private void Drop()
    {
        if (Input.GetKeyDown(KeyCode.R) || ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Menu))
        {
            Debug.Log("drop triggered");
            int x = inventory.itemList.Count;
            float space = 3;
            
            for (int i = 0; i < x; i++)
            {
                Vector3 pos = new Vector3(space, 0, 0);
                pos = pos + transform.position;
                if(inventory.itemList[i].activeSelf)
                {
                    GameObject t = inventory.itemList[i];
                    t.transform.SetParent(null);
                    t.transform.position = pos;
                    t.SetActive(true);
                    t.GetComponent<MeshCollider>().enabled = true;
                    //GameObject temp = Instantiate(inventory.itemList[i], pos, Quaternion.identity) as GameObject;
                    //temp.SetActive(true);
                    inventory.itemList.RemoveAt(i);
                    current -= 1;

                    // 顯示 噴槍時間
                    GameObject.FindGameObjectWithTag("TimeText").GetComponent<Text>().text = " " ;
                    Debug.Log("drop completed");
                }
            }
           // Debug.Log(("inventory count: ") );
            //Debug.Log(inventory.itemList.Count);
            
        }
    }

    //grab the item when player touches item on the ground
    private void OnTriggerEnter(Collider collider)
    {
        int flag = 0;

        //Debug.Log("trigger");
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (inventory.itemList.Count < toolLimit)
        {
            //Debug.Log("trigger");
            //touch item get item
            if (itemWorld != null && inventory.itemList.Count == 0)
            {
                inventory.AddItem(itemWorld.GetItem());
                itemWorld.GetItem().transform.SetParent(GameObject.FindGameObjectWithTag("RightHand").transform);
                itemWorld.GetItem().transform.position = GameObject.FindGameObjectWithTag("RightHand").transform.position;
                itemWorld.GetItem().transform.rotation = GameObject.FindGameObjectWithTag("RightHand").transform.rotation;
                itemWorld.GetItem().GetComponent<MeshCollider>().enabled = false;
                Debug.Log("Mesh disabled");
                //修正噴槍歪掉
                itemWorld.GetItem().transform.localEulerAngles = new Vector3(72.0f, 0.0f, 0.0f);

                // 顯示 噴槍時間
                GameObject.FindGameObjectWithTag("TimeText").GetComponent<Text>().text = " " + (itemWorld.remainingTime / 30) + "s";
                //Debug.Log("Time found");

                
                current += 1;
                GameObject.Find("Pickup").GetComponent<AudioSource>().Play();
            }
            else if(itemWorld != null && inventory.itemList.Count != 0 )
            {
                inventory.AddItem(itemWorld.GetItem());
                itemWorld.GetItem().transform.SetParent(GameObject.FindGameObjectWithTag("RightHand").transform);
                itemWorld.GetItem().transform.position = GameObject.FindGameObjectWithTag("RightHand").transform.position;
                itemWorld.GetItem().transform.rotation = GameObject.FindGameObjectWithTag("RightHand").transform.rotation;

                //修正噴槍歪掉
                itemWorld.GetItem().transform.localEulerAngles = new Vector3(72.0f, 0.0f, 0.0f); 

                itemWorld.GetItem().GetComponent<MeshCollider>().enabled = false;
                itemWorld.DestroySelf();
                current += 1;
                GameObject.Find("Pickup").GetComponent<AudioSource>().Play();
            }
            
        }

    }
}
