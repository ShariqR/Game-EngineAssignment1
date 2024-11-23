using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreObserver : MonoBehaviour, IObserver<int>
{
    private GameManager gameManager;
    private UIManager uiManager;
    
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
        if (gameManager != null)
        {
            gameManager.AddObserver(this);
        }
        
        uiManager = FindObjectOfType<UIManager>();
    }

    public void OnNotify(int updatedScore)
    {
        uiManager.MarkScoreDirty(updatedScore);
    }
    
    private void OnDestroy()
    {
        if (gameManager != null)
        {
            gameManager.RemoveObserver(this);
        }
    }
}
