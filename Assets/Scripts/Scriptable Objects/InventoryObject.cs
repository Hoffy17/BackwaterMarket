using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Scriptable Object

/// <summary>
/// Contains a list of <see cref="ItemObject"/> assets.
/// </summary>
[CreateAssetMenu(fileName = "New Inventory", menuName = "Scriptable Objects/Inventory")]
public class InventoryObject : ScriptableObject
{
    /// <summary>
    /// A list of <see cref="ItemObject"/> assets held in an <see cref="InventoryObject"/> asset.
    /// </summary>
    [Tooltip("A list of ItemObject assets held in an inventory asset.")]
    public List<InventorySlot> inventoryList = new List<InventorySlot>();

    /// <summary>
    /// Adds an <see cref="ItemObject"/> to the <see cref="InventoryObject"/> data file.
    /// </summary>
    /// <param name="addedItem"></param>
    public void AddItem(ItemObject addedItem)
    {
        inventoryList.Add(new InventorySlot(addedItem));
    }
}

#endregion

/// <summary>
/// A container that holds a single <see cref="ItemObject"/> in an <see cref="InventoryObject"/>.
/// </summary>
[Serializable]
public class InventorySlot
{
    public ItemObject item;

    public InventorySlot(ItemObject addedItem)
    {
        item = addedItem;
    }
}