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

    [Header("UI")]

    /// <summary>
    /// The <see cref="GameObject"/> containing the Buy menu and its children.
    /// </summary>
    [Tooltip("The game object containing the Buy menu and its children.")]
    public GameObject buyMenu;
    /// <summary>
    /// The <see cref="GameObject"/> containing the Inventory menu and its children.
    /// </summary>
    [Tooltip("The game object containing the Inventory menu and its children.")]
    public GameObject inventoryMenu;

    #endregion


    #region Unity Functions

    private void Start()
    {
        balance = startingBalance;
        PrintBalance();
    }

    #endregion


    #region Custom Functions

    public void PrintBalance()
    {
        balanceTMP.text = balance.ToString("c2");
    }

    #endregion
}