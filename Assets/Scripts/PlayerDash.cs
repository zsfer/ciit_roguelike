using System.Linq;
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

    private int m_dashCharge;

    [SerializeField] private TextMeshProUGUI m_dashTip;
    [SerializeField] private TextMeshProUGUI m_dashChargeText;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();

        GetComponent<PlayerMovement>().PlayerInput.Player.Dash.performed += Dash;

        m_dashTip.gameObject.SetActive(false);
    }

    private bool m_canDash => m_dashCharge > 0;

    private void Dash(InputAction.CallbackContext context)
    {
        if (!m_canDash) return;
        StartCoroutine("IFrame");

        m_rb.AddForce(m_dashDistance * m_dashMultiplier * m_rb.velocity.normalized);
        AddDash(-1);
    }

    public void AddDash(int amount = 1)
    {
        m_dashCharge += amount;
        m_dashTip.gameObject.SetActive(m_canDash);
        m_dashChargeText.text = "Dash " + string.Concat(Enumerable.Repeat("+", m_dashCharge));
    }

    private IEnumerator IFrame()
    {
        GetComponent<HealthComponent>().Invincible = true;
        yield return new WaitForSeconds(0.5f);
        GetComponent<HealthComponent>().Invincible = false;
    }

}
