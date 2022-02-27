using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Declarations

    [SerializeField]
    private InventoryObject inventory;

    [Header("Inventory Setup")]
    [SerializeField]
    private Vector3 firstItemSlotPos;
    [SerializeField]
    private Vector3 itemSlotDimensions;
    [SerializeField]
    private int numInventoryColumns;

    [NonSerialized]
    //A dictionary containining a list of items in the inventory scriptable object, and their gameobjects on the canvas
    private Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    #endregion


    #region Unity Functions

    private void Start()
    {
        CreateDisplay();
    }

    private void Update()
    {
        UpdateDisplay();
    }

    private void OnApplicationQuit()
    {
        inventory.inventoryList.Clear();
    }

    #endregion


    #region Custom Functions

    private void CreateDisplay()
    {
        for (int i = 0; i < inventory.inventoryList.Count; i++)
            AddItem(i);
    }

    private void UpdateDisplay()
    {
        for (int i = 0; i < inventory.inventoryList.Count; i++)
        {
            //Checks if the dictionary contains the same items in the inventoryList
            if (itemsDisplayed.ContainsKey(inventory.inventoryList[i]))
                break;
            //If the inventoryList contains items that are not in the dictionary, add them
            else
                AddItem(i);
        }
    }

    private void AddItem(int i)
    {
        //Instantiate the new item's prefab
        var obj = Instantiate(inventory.inventoryList[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
        //Determine the prefab's Vector3 position in the inventory
        obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
        //Add the new item to the dictionary
        itemsDisplayed.Add(inventory.inventoryList[i], obj);
    }

    private Vector3 GetPosition(int i)
    {
        //Calculate the position of each added item on the canvas, based on the first item's position, the local space between items, and the number of columns
        return new Vector3(firstItemSlotPos.x + (itemSlotDimensions.x * (i % numInventoryColumns)), firstItemSlotPos.y + (-itemSlotDimensions.y * (i/numInventoryColumns)), 0f);
    }

    #endregion
}
