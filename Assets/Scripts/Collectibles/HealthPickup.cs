using UnityEngine;

public class HealthPickup : CollectibleBase
{
    [SerializeField] int healAmount = 30;

    public override void Collect()
    {
        Debug.Log("i feel so much better!");
        
        PlayerController player = GameObject.FindWithTag("Player")?.GetComponent<PlayerController>();

        if (player != null)
        {
            player.Heal(healAmount);
        }
        else
        {
            Debug.LogError("Playercontroller not found");
        }
        
        Destroy(gameObject);
    }
}
