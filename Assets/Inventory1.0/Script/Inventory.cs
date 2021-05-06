using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// control player's inventory
public class Inventory 
{
    public List<GameObject> itemList;

    public Inventory(){
        itemList = new List<GameObject>();
        // AddItem(new Item {itemType = Item.ItemType.paint1, amount = 2});

    }

    // add item into inventory
    public void AddItem(GameObject item){

        itemList.Add(item);
        Debug.Log("Get item");
        Debug.Log(itemList.Count);
    }
}
