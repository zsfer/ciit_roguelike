using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Collectible
{
    public int HealAmount = 100;

    protected override void UseItem(GameObject target)
    {
        target.GetComponent<HealthComponent>().Heal(HealAmount);

        base.UseItem(target);
    }
}
