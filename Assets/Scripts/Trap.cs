using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public string TrapName = "Trap";

    public bool InstantDamage = true;

    public int Damage = 50;
    public int Cooldown = 3;

    private Animator m_anim;

    private bool m_isActive = false;
    private GameObject m_target;

    private FollowTarget m_follow;

    void Start()
    {
        m_anim = GetComponent<Animator>();
        m_follow = GetComponent<FollowTarget>();
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.CompareTag("Player") && !m_isActive)
        {
            m_isActive = true;
            m_anim.SetBool("Active", true);

            m_target = col.gameObject;

            m_follow.enabled = false;

            if (InstantDamage) DamagePlayer();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        m_target = null;
    }

    void DamagePlayer()
    {
        m_target.GetComponent<HealthComponent>().Damage(Damage, TrapName);
        StartCoroutine(_Cooldown());
    }

    IEnumerator _Cooldown()
    {
        yield return new WaitForSeconds(Cooldown);
        m_isActive = false;
        m_anim.SetBool("Active", false);

        m_follow.enabled = true;
    }
}
