using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyController : MonoBehaviour
{
    [Header("Item Rarity")]
    [Tooltip("An array of thresholds that determine the rarity of an item.")]
    [SerializeField]
    public int[] rarityThresholds;
    [Tooltip("An array of multipliers factored in when items are bought and sold.")]
    [SerializeField]
    public float[] rarityMultipliers;
    public string[] rarityLabels;
}
