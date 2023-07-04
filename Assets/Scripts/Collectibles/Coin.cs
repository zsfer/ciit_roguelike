using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Jank no collision coin implementation
/// </summary>
public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            CoinSpawner.Instance.RemoveCoin(gameObject);
        }
    }
}
