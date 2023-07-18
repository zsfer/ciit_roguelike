using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVolume : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.StartGame();
        }
    }
}
