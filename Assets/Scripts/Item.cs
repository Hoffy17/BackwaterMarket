using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    [Header("Item Data")]
    public ItemObject itemObject;
    public float itemValue;
    public float itemCondition;
    public float itemRarityMultiplier;
    public string itemRarityLabel;

    private BuyController buyController;
    private BuyMenu buyMenu;

    private TextMeshProUGUI itemTypeText;
    private TextMeshProUGUI itemBuyingPriceText;

    private void Awake()
    {
        buyMenu = transform.parent.GetComponent<BuyMenu>();
    }

    private void GetTMPComponents()
    {
        itemTypeText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        itemBuyingPriceText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    public void BuyingPriceCalculator()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        buyController = gameController.GetComponent<BuyController>();

        itemCondition = UnityEngine.Random.value;
        int itemRarityValue = UnityEngine.Random.Range(0, 101);
        RarityCalculcator(itemRarityValue);

        itemValue = itemObject.baseValue * buyController.buyMultipler * itemCondition * itemRarityMultiplier;

        PrintData();
    }

    private void RarityCalculcator(int rarity)
    {
        for (int i = 0; i < buyController.rarityThresholds.Length; i++)
        {
            if (rarity >= buyController.rarityThresholds[i])
            {
                itemRarityMultiplier = buyController.rarityMultipliers[i];
                itemRarityLabel = buyController.rarityLabels[i];
            }
        }
    }

    private void PrintData()
    {
        GetTMPComponents();

        gameObject.GetComponentInChildren<Image>().sprite = itemObject.smallSprite;
        itemTypeText.text = itemObject.type.ToString();
        itemBuyingPriceText.text = itemValue.ToString("c2");
    }

    public void ItemSelect()
    {
        buyMenu.buyMenuSelector.SetActive(true);
        buyMenu.buyMenuSelector.transform.position = gameObject.transform.position;

        ItemPanel itemPanel = buyMenu.buyMenuItemPanel;

        itemPanel.panelItemArtwork.sprite = itemObject.largeSprite;
        itemPanel.panelItemTypeText.text = itemObject.type.ToString();
        itemPanel.panelItemBuyingPriceText.text = itemValue.ToString("c2");
        itemPanel.panelItemConditionText.text = "Condition: " + (itemCondition * 100).ToString("n0") + "%";
        itemPanel.panelItemRarityText.text = $"Rarity: {itemRarityLabel}";
    }
}