using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : MonoBehaviour
{
    [SerializeField]
    private float m_moveSpeed = 2;

    public Transform Target;

    private NavMeshAgent m_agent;

    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_agent.updateRotation = false;
        m_agent.updateUpAxis = false;
        m_agent.speed = m_moveSpeed;

        if (Target == null) {
            Target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        m_agent.SetDestination(Target.position);
    }
}
