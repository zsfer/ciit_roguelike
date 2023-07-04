using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPotion : Collectible
{
    public int RefillAmount = 1;

    protected override void UseItem(GameObject target)
    {
        target.GetComponent<PlayerDash>().AddDash(RefillAmount);
        base.UseItem(target);
    }
}
