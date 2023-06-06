using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D m_rb;
    private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * 3, m_rb.velocity.y);
        m_animator.SetFloat("Speed", Mathf.Abs(m_rb.velocity.x));
    }
}
