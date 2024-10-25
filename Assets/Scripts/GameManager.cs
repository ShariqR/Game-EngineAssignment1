using UnityEngine;

public class GameManager : Subject<int>
{
    public static GameManager Instance { get; private set; }
    
    public ScoreSubject scoreSubject;
    public ScoreUI scoreUI;

    private int score;
    
    private void Start()
    {
        //scoreSubject = FindObjectsByType<ScoreSubject>();
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        scoreSubject.AddObserver(scoreUI);
    }

    public void AddScore(int value)
    {
        score += value;
        NotifyObservers(score);
    }

    public int GetScore()
    {
        return score;
    }
}