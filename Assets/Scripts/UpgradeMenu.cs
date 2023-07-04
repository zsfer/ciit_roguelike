using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
class Upgrade
{
    public string name;
    public int currentLevel;
    public float valuePerUpgrade;
    public int cost;

    public IUpgradeable target;
}

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject m_upgradeCardPrefab;

    [SerializeField]
    private List<Upgrade> m_upgrades;

    void Start()
    {
        foreach (var upgrade in m_upgrades)
        {
            var card = Instantiate(m_upgradeCardPrefab, transform);
            card.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = upgrade.name;
            card.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = string.Concat(Enumerable.Repeat("*", upgrade.currentLevel));
            card.GetComponentInChildren<Button>().onClick.AddListener(() => {
                upgrade.target.Upgrade(upgrade.valuePerUpgrade);
                upgrade.currentLevel++;
            });
        }
    }

}
