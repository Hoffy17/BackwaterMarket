using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryDisplayPlayer : InventoryDisplay
{
    #region Declarations

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

    #endregion

    private void OnApplicationQuit()
    {
        inventory.inventoryList.Clear();
    }
}