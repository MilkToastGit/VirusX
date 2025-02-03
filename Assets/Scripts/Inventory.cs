using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static int gasoline;

    public static void CollectGasoline(int amount)
    {
        gasoline += amount;
        Debug.Log(gasoline);
    }
}
