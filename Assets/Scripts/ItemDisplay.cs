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
    /// The <see cref="InventoryDisplay"/> component in which this item game object will display on the Inventory menu.
    /// </summary>
    [Tooltip("The Inventory Display component in which this item game object will display on the Inventory menu.")]
    public InventoryDisplayPlayer inventoryDisplayPlayer;
    /// <summary>
    /// The <see cref="InventoryDisplay"/> component in which this item game object will display on the Buy menu.
    /// </summary>
    [Tooltip("The Inventory Display component in which this item game object will display on the Buy menu.")]
    public InventoryDisplayBuy inventoryDisplayBuy;

    private GameManager gameManager;

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
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        if (gameManager.inventoryMenu.activeSelf == true)
        {
            inventoryDisplayPlayer = GameObject.FindGameObjectWithTag("Player Inventory").GetComponent<InventoryDisplayPlayer>();

            itemTypeText = inventoryDisplayPlayer.itemTypeText;
            itemArtwork = inventoryDisplayPlayer.itemArtwork;
            itemConditionText = inventoryDisplayPlayer.itemConditionText;
            itemRarityText = inventoryDisplayPlayer.itemRarityText;
            itemBuyingPriceText = inventoryDisplayPlayer.itemBuyingPriceText;
        }

        if (gameManager.buyMenu.activeSelf == true)
        {
            inventoryDisplayBuy = GameObject.FindGameObjectWithTag("Buy Inventory").GetComponent<InventoryDisplayBuy>();

            itemTypeText = inventoryDisplayBuy.itemTypeText;
            itemArtwork = inventoryDisplayBuy.itemArtwork;
            itemConditionText = inventoryDisplayBuy.itemConditionText;
            itemRarityText = inventoryDisplayBuy.itemRarityText;
            itemBuyingPriceText = inventoryDisplayBuy.itemBuyingPriceText;
        }
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
        if (gameManager.inventoryMenu.activeSelf == true)
        {
            inventoryDisplayPlayer.inventorySelector.SetActive(true);
            inventoryDisplayPlayer.inventorySelector.transform.localPosition = transform.localPosition;
        }

        if (gameManager.buyMenu.activeSelf == true)
        {
            inventoryDisplayBuy.inventorySelector.SetActive(true);
            inventoryDisplayBuy.inventorySelector.transform.localPosition = transform.localPosition;
        }
    }

    #endregion
}