using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackBehaviour : AIBehaviour
{
    public override bool Active => true;

    public float attackRange;
    public Transform target;

    public DogController controller;

    private void Update()
    {
        if (!Active)
            return;

        if (InRangeOfTarget())
            controller.SetAttacking(true);
        else
        {
            controller.SetAttacking(false);
            Approach();
        }
    }

    private bool InRangeOfTarget()
    {
        return Vector3.Distance(target.position, transform.position) < attackRange;
    }

    private void Approach()
    {
        controller.Move(target.position);
    }
}
