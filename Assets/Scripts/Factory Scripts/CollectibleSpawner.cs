using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public CollectibleType collectibleType;
    
    void Start()
    {
        GameObject collectible = CollectibleFactory.CreateCollectible(collectibleType);

        if (collectible != null)
        {
            //set position of spawned collectible
            collectible.transform.position = transform.position;
        }
    }
}
