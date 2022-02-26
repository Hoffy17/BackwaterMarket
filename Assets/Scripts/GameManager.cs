using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Declarations

    [Header("Balance")]
    public float balance;
    [SerializeField]
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