using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    private Inventory m_inventory;
    private LevellingComponent m_levelling;

    private Animator m_anim;

    public TextMeshProUGUI m_healthText;

    private void Start()
    {
        m_inventory = GetComponent<Inventory>();
        m_anim = GetComponent<Animator>();
        m_levelling = GetComponent<LevellingComponent>();

        var health = GetComponent<HealthComponent>();
        health.OnDie += Die;
        health.OnHealthChange += UpdateStatsUI;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            m_inventory.AddCoins();
            m_levelling.AddXP(1);
            CoinSpawner.Instance.RemoveCoin(collision.gameObject);
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
