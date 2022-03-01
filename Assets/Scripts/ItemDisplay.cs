using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDisplay : MonoBehaviour
{
    #region Declarations

    /// <summary>
    /// The <see cref="ItemObject"/> asset associated with this game object.
    /// </summary>
    [Tooltip("The Item Object asset associated with this game object.")]
    public ItemObject item;
    /// <summary>
    /// The <see cref="InventoryDisplay"/> component in which this item game object will display.
    /// </summary>
    [Tooltip("The Inventory Display component in which this item game object will display.")]
    public InventoryDisplay inventoryDisplay;

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


    #region Unity Functions

    private void Awake()
    {
        inventoryDisplay = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryDisplay>();

        itemTypeText = inventoryDisplay.itemTypeText;
        itemArtwork = inventoryDisplay.itemArtwork;
        itemConditionText = inventoryDisplay.itemConditionText;
        itemRarityText = inventoryDisplay.itemRarityText;
        itemBuyingPriceText = inventoryDisplay.itemBuyingPriceText;
    }

    #endregion


    #region Custom Functions

    public void DisplayItem()
    {
        itemTypeText.text = item.type.ToString();
        itemArtwork.sprite = item.artwork;
        itemConditionText.text = $"Condition: {item.condition.ToString()}%";
        itemRarityText.text = $"Rarity: {item.rarity.ToString()}";
        itemBuyingPriceText.text = $"Buying Price: {item.buyingPrice.ToString("c2")}";

        SetSelector();
    }

    private void SetSelector()
    {
        inventoryDisplay.inventorySelector.SetActive(true);
        inventoryDisplay.inventorySelector.GetComponent<RectTransform>().localPosition = gameObject.GetComponent<RectTransform>().localPosition;
    }

    #endregion
}