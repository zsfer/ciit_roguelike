using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed = 3f;

    private Rigidbody2D m_rb;
    private Animator m_animator;
    private PlayerInputActions m_input;

    [SerializeField] private LayerMask m_groundMask;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();

        m_input = new PlayerInputActions();
        m_input.Player.Enable();

        m_input.Player.Attack.performed += Attack;
    }

    void FixedUpdate()
    {
        m_rb.velocity = m_input.Player.Movement.ReadValue<Vector2>() * m_moveSpeed;
    }

    private void Attack(InputAction.CallbackContext context)
    {
        m_animator.ResetTrigger("Attack");
        m_animator.SetTrigger("Attack");
    }

    private void Update()
    {
        if (m_rb.velocity.sqrMagnitude > 0)
        {
            m_animator.SetFloat("X", m_rb.velocity.x);
            m_animator.SetFloat("Y", m_rb.velocity.y);
        }

        m_animator.SetLayerWeight(1, m_rb.velocity.sqrMagnitude);
    }

}
