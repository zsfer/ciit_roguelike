using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    private Inventory m_inventory;
    private PlayerDash m_dash;

    private Animator m_anim;

    public TextMeshProUGUI m_healthText;

    private void Start()
    {
        m_inventory = GetComponent<Inventory>();
        m_dash = GetComponent<PlayerDash>();
        m_anim = GetComponent<Animator>();

        var health = GetComponent<HealthComponent>();
        health.OnDie += Die;
        health.OnDamage += UpdateStatsUI;
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

    void UpdateStatsUI(int damage, int health) 
    {
        m_healthText.text = "Health " + health;
    }

    void Die(string causeOfDeath) 
    {
        m_anim.SetBool("Dead", true);
        GameManager.Instance.GameOver(causeOfDeath);
    }
}
