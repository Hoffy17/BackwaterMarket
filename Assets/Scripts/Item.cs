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
    public float itemRarity;

    private BuyMenu buyMenu;

    private TextMeshProUGUI itemTypeText;
    private TextMeshProUGUI itemBuyingPriceText;

    private void Awake()
    {
        buyMenu = transform.parent.GetComponent<BuyMenu>();

        itemTypeText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        itemBuyingPriceText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    public void PrintData()
    {
        itemValue = itemObject.baseValue;

        gameObject.GetComponentInChildren<Image>().sprite = itemObject.sprite;
        itemTypeText.text = itemObject.type.ToString();
        itemBuyingPriceText.text = itemValue.ToString("c2");
    }

    public void ItemSelect()
    {
        buyMenu.buyMenuSelector.SetActive(true);
        buyMenu.buyMenuSelector.transform.position = gameObject.transform.position;
    }
}