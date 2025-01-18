using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SeachBehaviour : AIBehaviour
{
    public override bool Active => true;

    public float SearchRadius;

    public float idleTimeout;

    private NavMeshAgent agent;
    private Animator animator;

    private float elapsedTimeIdling;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!Active)
            return;

        Roam();
        //UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    private void Roam()
    {
        Debug.Log(agent.velocity + ", " + elapsedTimeIdling);
        if (agent.velocity.magnitude <= 0)
        {
            elapsedTimeIdling += Time.deltaTime;
        }

        if (elapsedTimeIdling > idleTimeout)
        {
            Debug.Log(agent.destination);
            agent.SetDestination(GetRandomPoint());
            Debug.Log(agent.destination);

            elapsedTimeIdling = 0;
        }
    }

    private Vector3 GetRandomPoint()
    {
        float randomAngle = Random.Range(0f, 360f);
        float randomDistance = Random.Range(0f, SearchRadius);

        Vector2 angleVector = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
        Vector2 randomPoint2D = angleVector * randomDistance;

        Vector3 randomPoint = new Vector3(randomPoint2D.x, 0, randomPoint2D.y);

        randomPoint += transform.position;

        Debug.Log($"RandomPoint: {randomPoint}");


        return randomPoint;
    }
}
