using UnityEngine;

public enum CollectibleType
{
    Coin,
    Health
}

public class CollectibleFactory
{
    private GameObject _coinPrefab;
    private GameObject _healthPrefab;

    public CollectibleFactory()
    {
        _coinPrefab = LoadPrefab("Prefabs/Coin");
        _healthPrefab = LoadPrefab("Prefabs/HealthPickup");
    }

    private GameObject LoadPrefab(string path)
    {
        GameObject prefab = Resources.Load<GameObject>(path);

        if (prefab == null)
        {
            Debug.LogError("Prefab not found at path: " + path);
        }

        return prefab;
    }
    
    public GameObject CreateCollectible(CollectibleType type)
    {
        GameObject collectiblePrefab = null;

        switch (type)
        {
            case CollectibleType.Coin:
                return _coinPrefab != null ? Object.Instantiate(_coinPrefab) : null;
            case CollectibleType.Health:
                return _healthPrefab != null ? Object.Instantiate(_healthPrefab) : null;
            default:
                Debug.LogError("Collectible prefab not found for type: " + type);
                return null;
        }
    }
}
