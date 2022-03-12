using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the display and management of the game's Inventory menu.
/// </summary>
public class InventoryDisplay : MonoBehaviour
{
    #region Public Declarations

    [Tooltip("The Inventory Object asset associated with this game object.")]
    [SerializeField]
    public InventoryObject inventory;

    [Header("Inventory Setup")]

    [Tooltip("The position of the item at the top-left of the inventory.")]
    [SerializeField]
    private Vector3 firstItemSlotPos;
    [Tooltip("The displacement or space between individual item slots in the Inventory menu.")]
    [SerializeField]
    private Vector3 itemSlotDispl;
    [Tooltip("The number of columns in the Inventory menu.")]
    [SerializeField]
    private int numInventoryColumns;

    [Header("Inventory GUI")]

    /// <summary>
    /// A highlighted UI sprite that confirms the player's selection of an item on the Inventory menu.
    /// </summary>
    [Tooltip("A highlighted UI sprite that confirms the player's selection of an item on the Inventory menu.")]
    [SerializeField]
    public GameObject inventorySelector;

    #endregion


    #region Unity Functions

    private void Start()
    {
        UpdateDisplay();
    }

    #endregion


    #region Custom Functions

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.inventoryList.Count; i++)
        {
            AddItem(i);
        }
    }

    private void AddItem(int i)
    {
        //Instantiate the new item's prefab
        var obj = Instantiate(inventory.inventoryList[i].prefab, Vector3.zero, Quaternion.identity, transform);
        //Determine the prefab's Vector3 position in the inventory
        obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
    }

    private Vector3 GetPosition(int i)
    {
        //Calculate the position of each added item on the canvas, based on the first item's position, the local space between items, and the number of columns
        return new Vector3(firstItemSlotPos.x + (itemSlotDispl.x * (i % numInventoryColumns)), firstItemSlotPos.y + (-itemSlotDispl.y * (i/numInventoryColumns)), 0f);
    }

    #endregion
}
