using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyController : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private InventoryObject playerInventory;
    [SerializeField]
    private InventoryDisplayPlayer playerInventoryDisplay;
    [SerializeField]
    private InventoryObject buyInventory;
    [SerializeField]
    private InventoryDisplayBuy buyInventoryDisplay;

    [HideInInspector]
    public ItemObject selectedItem;

    public void BuyItem()
    {
        for (int i = 0; i < buyInventory.inventoryList.Count; i++)
        {
            if (buyInventory.inventoryList[i] = selectedItem)
            {
                buyInventory.RemoveItem(buyInventory.inventoryList[i]);
                AddToInventory();
            }
        }

        gameManager.balance -= selectedItem.buyingPrice;
        gameManager.PrintBalance();
    }

    public void AddToInventory()
    {
        playerInventory.AddItem(selectedItem);

        playerInventoryDisplay.UpdateDisplay();
        buyInventoryDisplay.UpdateDisplay();
    }
}