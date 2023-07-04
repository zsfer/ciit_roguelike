using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DieEventHandler(string causeOfDeath = "Natural Causes");
public delegate void DamageEventHandler(int damage, int health);

public class HealthComponent : MonoBehaviour
{
    [field: SerializeField]
    public int Health {get; private set;} = 100;

    public event DieEventHandler OnDie;
    public event DamageEventHandler OnDamage;

    private string m_recentDamageTakenFrom;

    public void Damage(int damage, string cause) 
    {
        Health -= damage;
        m_recentDamageTakenFrom = cause;

        OnDamage.Invoke(damage, Health);

        if (Health <= 0) Die(cause);
    }

    void Die(string cause) 
    {
        OnDie.Invoke(cause);
    }
}
