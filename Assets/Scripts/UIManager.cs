using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Image healthBar;
    
    private bool isScoreDirty = false;
    private bool isHealthDirty = false;
    
    private int score = 0;
    private int health = 0;

    private void Awake()
    {
        if (healthBar == null)
        {
            healthBar = GetComponentInChildren<Image>();
        }
    }
    
    public void MarkScoreDirty(int newScore)
    {
        isScoreDirty = true;
        score = newScore;
    }
    
    public void MarkHealthDirty(int newHealth)
    {
        isHealthDirty = true;
        health = newHealth;
    }

    private void LateUpdate()
    {
        if (isScoreDirty)
        {
            UpdateScoreUI();
            isScoreDirty = false;
        }

        if (isHealthDirty)
        {
            UpdateHealthUI();
            isHealthDirty = false;
        }
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
        Debug.Log("updated score");
    }

    private void UpdateHealthUI()
    {
        Debug.Log(health);
        
        float fillAmount = (float)health / 100;
        healthBar.fillAmount = fillAmount;
    }
}
