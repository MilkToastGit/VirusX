using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogController : MonoBehaviour
{
    public bool IsStopped => agent.velocity.magnitude <= 0;

    public Animator animator;
    public NavMeshAgent agent;

    public void SetAttacking(bool attacking)
    {
        animator.SetBool("Attacking", attacking);
    }

    public void Move(Vector3 targetDestination)
    {
        agent.SetDestination(targetDestination);
    }

    private void Update()
    {
        UpdateAnimatorSpeed();
    }

    private void UpdateAnimatorSpeed()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
}
