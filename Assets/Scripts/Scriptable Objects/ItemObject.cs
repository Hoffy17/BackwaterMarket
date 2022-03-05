using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Enumerators

/// <summary>
/// The enumerator that defines the item's type. 
/// </summary>
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

/// <summary>
/// The enumerator that defines the item's rarity.
/// </summary>
public enum ItemRarity
{
    Common,
    Uncommon,
    Rare,
    Unique
}

#endregion


#region Scriptable Object

/// <summary>
/// A <see cref="ScriptableObject"/> that stores variables that define an item.
/// </summary>
[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Objects/Item")]
public class ItemObject : ScriptableObject
{
    /// <summary>
    /// The <see cref="GameObject"/> that will inherit the variables from this <see cref="ScriptableObject"/>."
    /// </summary>
    [Tooltip("The GameObject that will inherit the variables from this ScriptableObject.")]
    public GameObject prefab;

    /// <summary>
    /// The enumerator that defines the item's type.
    /// </summary>
    [Tooltip("The enumerator that defines the item's type.")]
    public ItemType type;
    /// <summary>
    /// The sprite that will display for this item in the Inventory panel.
    /// </summary>
    [Tooltip("The sprite that will display for this item in the Inventory panel.")]
    public Sprite smallArtwork;
    /// <summary>
    /// The sprite that will display for this item in the item panel.
    /// </summary>
    [Tooltip("The sprite that will display for this item in the item panel.")]
    public Sprite largeArtwork;
    /// <summary>
    /// The item's condition, as an integer between 0 and 100.
    /// </summary>
    [Tooltip("The item's condition, as an integer between 0 and 100.")]
    public int condition;
    /// <summary>
    /// The enumerator that defines the item's rarity.
    /// </summary>
    [Tooltip("The enumerator that defines the item's rarity.")]
    public ItemRarity rarity;
    /// <summary>
    /// The amount that will be deducted from the player's balance when they buy the item.
    /// </summary>
    [Tooltip("The amount that will be deducted from the player's balance when they buy the item.")]
    public float buyingPrice;
}

#endregion