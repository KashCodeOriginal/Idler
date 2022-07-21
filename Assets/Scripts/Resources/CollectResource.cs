using System;
using UnityEngine;
using UnityEngine.Events;

public class CollectResource : MonoBehaviour
{
    public event UnityAction OreCollected;
    public event UnityAction WoodCollected;


    public void CollectOre()
    {
        OreCollected?.Invoke();
    }

    public void CollectWood()
    {
        WoodCollected?.Invoke();
    }
}
