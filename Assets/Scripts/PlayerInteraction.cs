using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Inventory m_inventory;
    private PlayerDash m_dash;

    private void Start()
    {
        m_inventory = GetComponent<Inventory>();
        m_dash = GetComponent<PlayerDash>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            m_inventory.AddCoins();
            CoinSpawner.Instance.RemoveCoin(collision.gameObject);
        }

        if (collision.CompareTag("DashPotion")) 
        {
            m_dash.AddDash();
            Destroy(collision.gameObject);
        }
    }
}
