using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Enumerators

public enum ItemType
{
    None,
    DiamondRing,
    GoldIngot,
    Necklace,
    Revolver,
    Rifle,
    SnakeOil,
    Watch
}

public enum ItemRarity
{
    Common,
    Uncommon,
    Rare,
    Unique
}

#endregion


#region Scriptable Object

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory System/Item")]
public class ItemObject : ScriptableObject
{
    public GameObject prefab;

    public ItemType type;
    public float condition;
    public ItemRarity rarity;
    public float buyingPrice;
}

#endregion