using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Handles the game's primary operations, including balance.
/// </summary>
public class GameManager : MonoBehaviour
{
    #region Declarations

    [Header("Balance")]

    /// <summary>
    /// How much money the player is currently holding.
    /// </summary>
    [Tooltip("How much money the player is currently holding.")]
    public float balance;
    [Tooltip("How much balance the player begins the game session with.")]
    [SerializeField]
    private float startingBalance;
    [SerializeField]
    [Tooltip("The TextMeshPro text component that displays the player's balance.")]
    private TMP_Text balanceTMP;

    #endregion


    #region Unity Functions

    private void Start()
    {
        balance = startingBalance;
        PrintBalance();
    }

    #endregion


    #region Custom Functions

    /// <summary>
    /// Deducts the bought item's price from the player's balance.
    /// </summary>
    /// <remarks>
    /// Called by the Buy button in the Buy menu.
    /// </remarks>
    /// <param name="boughtItem"></param>
    public void Buy(ItemObject boughtItem)
    {
        balance -= boughtItem.buyingPrice;
        PrintBalance();
    }

    private void PrintBalance()
    {
        balanceTMP.text = balance.ToString("c2");
    }

    #endregion
}