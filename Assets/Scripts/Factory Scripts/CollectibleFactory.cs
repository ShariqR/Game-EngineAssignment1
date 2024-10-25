using UnityEngine;

public enum CollectibleType
{
    Coin,
    Health
}

public class CollectibleFactory
{
    public static GameObject CreateCollectible(CollectibleType type)
    {
        GameObject collectiblePrefab = null;

        switch (type)
        {
            case CollectibleType.Coin:
                collectiblePrefab = Resources.Load<GameObject>("Prefabs/Coin");
                break;
            case CollectibleType.Health:
                collectiblePrefab = Resources.Load<GameObject>("Prefabs/HealthPickup");
                break;
        }

        if (collectiblePrefab != null)
        {
            return Object.Instantiate(collectiblePrefab);
        }
        else
        {
            Debug.LogError("Collectible prefab not found for type: " + type);
            return null;
        }
    }
}
