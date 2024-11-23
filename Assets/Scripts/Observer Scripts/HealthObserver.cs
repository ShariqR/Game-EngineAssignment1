using UnityEngine;
using UnityEngine.UI;

public class HealthObserver : MonoBehaviour, IObserver<int>
{
    private PlayerController player;
    private UIManager uiManager;
    
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();

        if (player != null)
        {
            player.AddObserver(this);
        }
        
        uiManager = FindObjectOfType<UIManager>();
    }

    public void OnNotify(int updatedHealth)
    {
        uiManager.MarkHealthDirty(updatedHealth);
    }
    
    private void OnDestroy()
    {
        if (player != null)
        {
            player.RemoveObserver(this);
        }
    }
}
