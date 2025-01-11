using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aidog : MonoBehaviour
{
    public Transform PlayerTransform;
    public float SearchRadius, ApproachRadius, AttackRadius;
    
    private enum DogStates {Idle, Search, Approach, Attack, Stagger}

    private DogStates currentState = DogStates.Idle;
    
    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, PlayerTransform.position);

        if(currentState == DogStates.Idle && distanceFromPlayer < SearchRadius)
        {
            StartSearch();
        }
    }  

    private void StartSearch()
    {
        currentState = DogStates.Search;
    }


}
