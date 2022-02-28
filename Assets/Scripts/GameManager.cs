using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Declarations
    /// <summary>
    /// How much money the player is currently holding.
    /// </summary>
    [Header("Balance")]
    [Tooltip("How much money the player is currently holding.")]
    public float balance;

    [SerializeField]
    [Tooltip("The TextMeshPro text component that displays the player's money balance.")]
    private TMP_Text balanceTMP;

    #endregion


    #region Unity Functions

    private void Start()
    {
        balance = 100f;
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