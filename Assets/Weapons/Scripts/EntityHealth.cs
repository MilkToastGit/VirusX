using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    public event Action OnLostAllHealth;

    public float Health;

    public void Damage(float damageAmount)
    {
        Health = Health - damageAmount;

        print(Health);

        if(Health <= 0)
        {
            Health = 0;
            
            if(OnLostAllHealth != null)
                OnLostAllHealth.Invoke();
        }
    }
}
