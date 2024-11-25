using System;
using UnityEngine;

public class AchievementTracker : MonoBehaviour, IObserver<int>
{
    private const int scoreNeeded = 50;

    [SerializeField] GameObject achievementNoti;

    private void Start()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.AddObserver(this);
        }
    }
    
    public void OnNotify(int score)
    {
        if (score >= scoreNeeded)
        {
            Debug.Log("achievement notified");
            achievementNoti.SetActive(true);
        }
    }
    
    private void OnDestroy()
    {
        //Detach when destroyed to avoid memory leaks
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.RemoveObserver(this);
        }
    }

    
}
