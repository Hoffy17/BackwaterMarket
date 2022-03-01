using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Handles the display and management of the game's Inventory menu.
/// </summary>
public class InventoryDisplay : MonoBehaviour
{
    #region Declarations

    [Tooltip("The Inventory Object asset associated with this game object.")]
    [SerializeField]
    private InventoryObject inventory;

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

    [Header("Item Panel GUI")]

    /// <summary>
    /// Displays the name of the selected item inside the Item Panel in the Inventory menu.
    /// </summary>
    [Tooltip("Displays the name of the selected item inside the Item Panel in the Inventory menu.")]
    public TextMeshProUGUI itemTypeText;
    /// <summary>
    /// Displays large artwork of the selected item inside the Item Panel in the Inventory menu.
    /// </summary>
    [Tooltip("Displays large artwork of the selected item inside the Item Panel in the Inventory menu.")]
    public Image itemArtwork;
    /// <summary>
    /// Displays the condition of the selected item inside the Item Panel in the Inventory menu.
    /// </summary>
    [Tooltip("Displays the condition of the selected item inside the Item Panel in the Inventory menu.")]
    public TextMeshProUGUI itemConditionText;
    /// <summary>
    /// Displays the rarity of the selected item inside the Item Panel in the Inventory menu.
    /// </summary>
    [Tooltip("Displays the rarity of the selected item inside the Item Panel in the Inventory menu.")]
    public TextMeshProUGUI itemRarityText;
    /// <summary>
    /// Displays the buying price of the selected item inside the Item Panel in the Inventory menu.
    /// </summary>
    [Tooltip("Displays the buying price of the selected item inside the Item Panel in the Inventory menu.")]
    public TextMeshProUGUI itemBuyingPriceText;

    [NonSerialized]
    //A dictionary containing a list of items in the inventory scriptable object, and their gameobjects on the canvas
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
        return new Vector3(firstItemSlotPos.x + (itemSlotDispl.x * (i % numInventoryColumns)), firstItemSlotPos.y + (-itemSlotDispl.y * (i/numInventoryColumns)), 0f);
    }

    #endregion
}
