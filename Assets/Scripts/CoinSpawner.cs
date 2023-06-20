using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private int m_coinSpawnCount;
    [SerializeField] private GameObject m_coinPrefab;

    [SerializeField] private Vector2 m_spawnBox;

    private readonly List<GameObject> m_coins = new();

    public static CoinSpawner Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < m_coinSpawnCount; i++)
        {
            m_coins.Add(Instantiate(m_coinPrefab, GetRandomPosition(m_spawnBox), Quaternion.identity, transform));
        }
    }

    private Vector2 GetRandomPosition(Vector2 bounds) =>
        new (Random.Range(-bounds.x, bounds.x), Random.Range(-bounds.y, bounds.y));

    public void RemoveCoin(GameObject coin)
    {
        m_coins.Find(x => x == coin).SetActive(false);

        var c = m_coins.FindLast(x => !x.activeSelf);
        c.transform.position = GetRandomPosition(m_spawnBox);
        c.SetActive(true);
    }
}
