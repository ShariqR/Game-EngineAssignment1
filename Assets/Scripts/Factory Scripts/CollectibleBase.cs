using System;
using UnityEngine;

public abstract class CollectibleBase : MonoBehaviour, ICollectible
{
    public abstract void Collect();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }
}
