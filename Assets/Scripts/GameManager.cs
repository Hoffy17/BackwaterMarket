using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Handles the win and lose conditions for the game.
/// </summary>
public class GameManager : MonoBehaviour
{
    #region Public Variables
    [Header("Balance")]
    [Tooltip("How much money the player is holding at any one time.")]
    [SerializeField]
    public float balance;
    [Tooltip("How much balance the player begins the game with.")]
    [SerializeField]
    private float startingBalance;
    [Tooltip("How much balance the player must achieve to win the game.")]
    [SerializeField]
    public float winningBalance;

    [Header("UI")]
    [SerializeField]
    [Tooltip("Displays the player's current balance.")]
    private TextMeshProUGUI balanceText;
    /// <summary>
    /// Used for checking whether a win or lose condition has been met.
    /// </summary>
    [HideInInspector]
    public bool gameOver;
    #endregion

    #region Hidden Variables
    #endregion

    #region Unity Functions
    private void Awake()
    {
        balance = startingBalance;
        PrintBalance();
    }
    #endregion

    /// <summary>
    /// Update the player's current balance on the user interface.
    /// </summary>
    #region Custom Functions
    public void PrintBalance()
    {
        balanceText.text = balance.ToString("c2");
    }
    #endregion
}
