using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CraftSystem
{
   private const int gridSize = 1;
   private Item[,] itemArray;

   public CraftSystem()
   {
      itemArray = new Item[gridSize, gridSize];
   }

   private bool isEmpty(int x, int y)
   {
      return itemArray[x, y] == null;
   }

   public Item GetItem(int x, int y)
   {
      return itemArray[x, y];
   }
}


