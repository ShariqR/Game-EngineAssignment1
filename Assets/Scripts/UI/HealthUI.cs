using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour, IObserver<int>
{
    [SerializeField] private Image healthBar;

    private void Awake()
    {
        if (healthBar == null)
        {
            healthBar = GetComponentInChildren<Image>();
        }
    }

    public void OnNotify(int health)
    {
        Debug.Log(health);
        
        float fillAmount = (float)health / 100;
        healthBar.fillAmount = fillAmount;
    }
}
