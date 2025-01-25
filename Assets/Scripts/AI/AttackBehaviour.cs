using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackBehaviour : AIBehaviour
{
    public override bool Active => true;

    public float attackRange;
    public Transform target;

    public Animator animator;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!Active)
            return;

        if (InRangeOfTarget())
            SetAttacking(true);
        else
        {
            SetAttacking(false);
            Approach();
        }
    }

    private bool InRangeOfTarget()
    {
        return Vector3.Distance(target.position, transform.position) < attackRange;
    }

    private void Approach()
    {
        agent.SetDestination(target.position);
    }

    private void SetAttacking(bool attacking)
    {
        animator.SetBool("Attacking", attacking);
    }
}
