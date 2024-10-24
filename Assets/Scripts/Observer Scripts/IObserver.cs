using UnityEngine;

public interface IObserver
{
    //Subject uses this method to communicate with the observer
    public void OnNotify(int health)
    {
        
    }
}
