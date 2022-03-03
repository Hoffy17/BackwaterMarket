using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryDisplayBuy : InventoryDisplay
{
    #region Declarations

    /// <summary>
    /// A list of the item types displayed in the Buy menu at any one time.
    /// </summary>
    [Tooltip("A list of the item types displayed in the Buy menu at any one time.")]
    public List<TextMeshProUGUI> itemTypeList;
    /// <summary>
    /// A list of the items' buying prices displayed in the Buy menu at any one time.
    /// </summary>
    [Tooltip("A list of the items' buying prices displayed in the Buy menu at any one time.")]
    public List<TextMeshProUGUI> itemBuyingPriceList;

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

    private void Awake()
    {
        for (int i = 0; i < inventory.inventoryList.Count; i++)
        {
            itemTypeList[i].text = inventory.inventoryList[i].item.type.ToString();
            itemBuyingPriceList[i].text = inventory.inventoryList[i].item.buyingPrice.ToString("c2");
        }
    }
}