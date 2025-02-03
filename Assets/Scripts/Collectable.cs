using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Inventory.CollectGasoline(1);
            Destroy(gameObject);
        }
    }
}
