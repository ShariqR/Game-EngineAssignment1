using UnityEditor;
using UnityEngine;

public class Coin : CollectibleBase
{
    public int scoreAdded = 10;
    [SerializeField] AudioClip collectSound;
    public override void Collect()
    {
        Debug.Log("money money money");
        AudioManager.Instance.PlaySFX(collectSound);
        GameManager gameManager = FindObjectOfType<GameManager>();
        
        if (gameManager != null)
        {
            gameManager.AddScore(scoreAdded);
        }
        else
        {
            Debug.LogError("GameManager not found");
        }
        
        Destroy(gameObject);
    }
}
