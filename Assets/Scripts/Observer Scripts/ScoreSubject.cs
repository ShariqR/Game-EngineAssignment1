using UnityEngine;

public class ScoreSubject : Subject<int>
{
    private int score = 0;
    
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
