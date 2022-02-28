using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDisplay : MonoBehaviour
{
    public ItemObject item;
    public InventoryDisplay inventoryDisplay;

    [Header("Item Panel GUI")]
    public TextMeshProUGUI itemTypeText;
    public Image itemArtwork;
    public TextMeshProUGUI itemConditionText;
    public TextMeshProUGUI itemRarityText;
    public TextMeshProUGUI itemBuyingPriceText;

    private void Awake()
    {
        inventoryDisplay = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryDisplay>();

        itemTypeText = inventoryDisplay.itemTypeText;
        itemArtwork = inventoryDisplay.itemArtwork;
        itemConditionText = inventoryDisplay.itemConditionText;
        itemRarityText = inventoryDisplay.itemRarityText;
        itemBuyingPriceText = inventoryDisplay.itemBuyingPriceText;
    }

    public void DisplayItem()
    {
        itemTypeText.text = item.type.ToString();
        itemArtwork.sprite = item.artwork;
        itemConditionText.text = $"Condition: {item.condition.ToString()}%";
        itemRarityText.text = $"Rarity: {item.rarity.ToString()}";
        itemBuyingPriceText.text = $"Buying Price: {item.buyingPrice.ToString("c2")}";
    }
}