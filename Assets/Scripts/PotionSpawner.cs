using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_potionList = new();

    [SerializeField] private float m_spawnDuration = 5f;

    [SerializeField] private Vector2 m_spawnBox;

    void Start()
    {
        StartCoroutine("SpawnPotions");   
    }

    IEnumerator SpawnPotions() 
    {
        while (true)
        {
            yield return new WaitForSeconds(m_spawnDuration);
            var spawn = GetRandomItem(m_potionList);
            Instantiate(spawn, GetRandomPosition(m_spawnBox), Quaternion.identity, transform);
        }
    }

    GameObject GetRandomItem(List<GameObject> list) => m_potionList[Random.Range(0, m_potionList.Count)];

    private Vector2 GetRandomPosition(Vector2 bounds) =>
        new (Random.Range(-bounds.x, bounds.x), Random.Range(-bounds.y, bounds.y));
}
