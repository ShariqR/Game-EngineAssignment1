using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour, IObserver<int>
{
    [SerializeField] private Text scoreText;

    private void Start()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.AddObserver(this);
        }
    }

    public void OnNotify(int newScore)
    {
        scoreText.text = "Score: " + newScore.ToString();
        Debug.Log("updated score");
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
