using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [field: SerializeField]
    public int Coins { get; private set; }

    [Header("UI")]
    public TextMeshProUGUI CoinsText;

    public delegate void InventoryNotify(int coins);
    public event InventoryNotify OnInventoryUpdate;

    public void AddCoins(int amount = 1)
    {
        Coins += amount;
        UpdateInventory();
    }

    public void RemoveCoins(int amount)
    {
        Coins -= amount;
        UpdateInventory();
    }

    void UpdateInventory()
    {
        CoinsText.text = "Coins " + Coins;
        OnInventoryUpdate?.Invoke(Coins);
    }

}
