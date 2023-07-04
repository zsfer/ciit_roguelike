using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePotion : Collectible
{
    [SerializeField]
    public float m_refillTime = 60;

    protected override void UseItem(GameObject target)
    {
        GameManager.Instance.Timer.AddTime(m_refillTime);

        base.UseItem(target);
    }
}
