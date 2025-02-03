using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SearchBehaviour : AIBehaviour
{
    public override bool Active => true;

    public float SearchRadius;
    public float idleTimeout;

    public DogController controller;

    private float elapsedTimeIdling;

    private void Update()
    {
        if (!Active)
            return;
        
        Roam();
    }

    private void Roam()
    {
        if (controller.IsStopped)
        {
            elapsedTimeIdling += Time.deltaTime;
        }

        if (elapsedTimeIdling > idleTimeout)
        {
            controller.Move(GetRandomPoint());

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

        return randomPoint;
    }
}
