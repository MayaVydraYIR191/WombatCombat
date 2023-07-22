using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject inventory;
    private bool inventoryOn;
    private List<Item> itemlist;
    public Text itemnum;

    private void Start()
    {
        inventoryOn = false;
    }

    public void Chest()
    {
        if (inventoryOn == false)
        {
            inventoryOn = true;
            inventory.SetActive(true);
        }
        else if (inventoryOn == true)
        {
            inventoryOn = false;
            inventory.SetActive(false);
        }
    }

    public Inventory()
    {
        itemlist = new List<Item>();
      AddItem(new Item{itemType = Item.ItemType.Grass,amount =1});
    }

    public void AddItem(Item item)
    {
        if(item.IsStackable())
        {
              foreach (Item inventoryItem in itemlist) 
              {
                  if(inventoryItem.itemType == item.itemType)
                      {
                          inventoryItem.amount +=item.amount;
                         itemnum.text = inventoryItem.amount.ToString();
                      }
              }
        }
        else 
        {
            itemlist.Add(item);
        }
    }
}

