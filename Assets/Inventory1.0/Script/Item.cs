using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
// different types of tools/items for inventory
public class Item
{
    public enum ItemType{
        paint1,
        paint2,
        paint3,
    }

    public ItemType itemType;
}
