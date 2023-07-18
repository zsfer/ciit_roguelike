using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DieEventHandler(string causeOfDeath = "Natural Causes");
public delegate void HealthChangeHandler(int damage, int health);

public class HealthComponent : Upgradable
{
    public int MAX_HEALTH = 100;

    [field: SerializeField]
    public int Health { get; private set; } = 100;

    public bool Invincible { get; set; }

    public event DieEventHandler OnDie;
    public event HealthChangeHandler OnHealthChange;

    private string m_recentDamageTakenFrom;

    [SerializeField] GameObject m_shields;

    public void Damage(int damage, string cause)
    {
        if (Invincible) return;

        Health -= damage;
        m_recentDamageTakenFrom = cause;

        OnHealthChange.Invoke(damage, Health);

        if (Health <= 0) Die("Died to " + cause);
    }

    void Die(string cause)
    {
        OnDie.Invoke(cause);
    }

    public void Heal(int healAmount)
    {
        if (Health < MAX_HEALTH)
            Health += healAmount;
        OnHealthChange.Invoke(0, Health);
    }

    public override void Upgrade(float value)
    {
        MAX_HEALTH += (Mathf.RoundToInt(value));
        Heal(MAX_HEALTH);
    }

    private void Update() {
        m_shields.SetActive(Invincible);
    }
}
