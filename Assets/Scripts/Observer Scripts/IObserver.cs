using UnityEngine;

public interface IObserver<T>
{
    //Subject uses this method to communicate with the observer
    public void OnNotify(T value)
    {
        
    }
}
