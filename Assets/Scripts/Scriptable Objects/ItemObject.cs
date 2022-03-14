using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    DiamondRing,
    Necklace,
    Revolver,
    Rifle,
    SnakeOil,
    Watch
}

/// <summary>
/// A <see cref="ScriptableObject"/> that contains data on the different items in the game.
/// </summary>
[CreateAssetMenu(menuName = "Inventory/Item Object")]
public class ItemObject : ScriptableObject
{
    [Tooltip("The kind of item.")]
    public ItemType type;
    public Sprite sprite;
    public int ID;
    [Tooltip("The base value of any individual item before any multipliers are calculated.")]
    public float baseValue;
}