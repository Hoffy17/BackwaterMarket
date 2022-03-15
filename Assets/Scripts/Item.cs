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
    public float itemRarityMultipler;
    public string itemRarityLabel;

    private BuyController buyController;
    private BuyMenu buyMenu;

    [SerializeField]
    private TextMeshProUGUI itemTypeText;
    [SerializeField]
    private TextMeshProUGUI itemBuyingPriceText;

    private void Awake()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");

        buyController = gameController.GetComponent<BuyController>();
        buyMenu = transform.parent.GetComponent<BuyMenu>();

        itemCondition = UnityEngine.Random.value;
        int itemRarityValue = UnityEngine.Random.Range(0, 101);

        RarityCalculcator(itemRarityValue);

        GetTMPComponents();
    }

    private void GetTMPComponents()
    {
        itemTypeText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        itemBuyingPriceText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    private void RarityCalculcator(int rarity)
    {
        for (int i = 0; i < buyController.rarityThresholds.Length; i++)
        {
            if (rarity >= buyController.rarityThresholds[i])
            {
                itemRarityMultipler = buyController.rarityMultipliers[i];
                itemRarityLabel = buyController.rarityLabels[i];
            }
        }
    }

    public void PrintData()
    {
        itemValue = itemObject.baseValue;

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