using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform m_target;
    [SerializeField] private float m_lerp = 10;

    private Vector3 m_offset;

    void Start()
    {
        if (m_target == null)
            m_target = GameObject.FindGameObjectWithTag("Player").transform;

        m_offset = Vector3.forward * -10;
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, m_offset + m_target.position, m_lerp * Time.deltaTime);
    }
}
