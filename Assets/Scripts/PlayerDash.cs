using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private float m_dashDistance = 1f;

    private readonly float m_dashMultiplier = 1000f;
    private Rigidbody2D m_rb;

    private Inventory m_inventory;
    private bool m_canDash;

    [SerializeField] private TextMeshProUGUI m_dashTip;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_inventory = GetComponent<Inventory>();
        m_inventory.OnInventoryUpdate += UpdateDash;

        GetComponent<PlayerMovement>().PlayerInput.Player.Dash.performed += Dash;

        m_dashTip.gameObject.SetActive(false);  
    }

    void UpdateDash(int coins)
    {
        m_canDash = coins >= 5;

        m_dashTip.gameObject.SetActive(m_canDash);
    }

    private void Dash(InputAction.CallbackContext context)
    {
        if (!m_canDash) return;
        m_rb.AddForce(m_dashDistance * m_dashMultiplier * m_rb.velocity.normalized);
        m_inventory.RemoveCoins(5);
    }

}
