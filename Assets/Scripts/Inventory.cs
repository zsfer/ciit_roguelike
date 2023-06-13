using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [field: SerializeField]
    public int Coins { get; set; }


    [Header("UI")]
    public TextMeshProUGUI CoinsText;

    void Update()
    {
        CoinsText.text = "Coins " + Coins;
    }
}
