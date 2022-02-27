using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Scriptable Object

[CreateAssetMenu(fileName = "New Inventory", menuName = "Scriptable Objects/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> inventoryList = new List<InventorySlot>();

    public void AddItem(ItemObject addedItem)
    {
        inventoryList.Add(new InventorySlot(addedItem));
    }
}

#endregion


[Serializable]
public class InventorySlot
{
    public ItemObject item;

    public InventorySlot(ItemObject addedItem)
    {
        item = addedItem;
    }
}