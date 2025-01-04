using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxDamage : MonoBehaviour
{
    public float damageAmount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out EntityHealth otherHealth))
        {
            otherHealth.Damage(damageAmount);
        }
    }
}
