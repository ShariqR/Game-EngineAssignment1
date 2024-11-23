using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    void Start()
    {
        CollectibleFactory factory = new CollectibleFactory();
        
        GameObject coin = factory.CreateCollectible(CollectibleType.Coin);
        GameObject healthPickup = factory.CreateCollectible(CollectibleType.Health);

        if (coin != null)
        {
            //set position of spawned collectible
            coin.transform.position = transform.position;
        }
        else if (healthPickup != null)
        {
            healthPickup.transform.position = transform.position;
        }
    }
}
