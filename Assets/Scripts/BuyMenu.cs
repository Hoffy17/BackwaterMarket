using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMenu : MonoBehaviour
{
    [Header("Inventory")]
    public List<ItemObject> itemTemplates;
    public List<GameObject> itemSlots = new List<GameObject>();

    [Header("UI")]
    public GameObject buyMenuSelector;

    private void OnEnable()
    {
        buyMenuSelector.SetActive(false);

        foreach (Transform child in transform)
            itemSlots.Add(child.gameObject);

        for (int i = 0; i < itemSlots.Count; i++)
        {
            int randomID = UnityEngine.Random.Range(0, itemTemplates.Count);

            for (int j = 0; j < itemTemplates.Count; j++)
            {
                if (randomID == itemTemplates[j].ID)
                {
                    itemSlots[i].GetComponent<Item>().itemObject = itemTemplates[j];
                    break;
                }
            }

            itemSlots[i].GetComponent<Item>().PrintData();
        }
    }

    private void OnDisable()
    {
        itemSlots.Clear();
        buyMenuSelector.SetActive(false);
    }
}
