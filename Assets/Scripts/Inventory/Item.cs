using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item
{
    public enum ItemType
    {
        Grass,
        Cube,
    }

    public ItemType itemType;
    public int amount;

    public bool IsStackable()
    {
        switch (itemType)
        { default:
            case ItemType.Grass:
                return true;
        case ItemType.Cube:
            return false;
        }
    }



}
