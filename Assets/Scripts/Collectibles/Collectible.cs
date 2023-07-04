using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    protected virtual void UseItem(GameObject target) {}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            UseItem(col.gameObject);

            Destroy(gameObject);
        }
    }

}
