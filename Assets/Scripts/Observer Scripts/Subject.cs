using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject<T> : MonoBehaviour
{
    private List<IObserver<T>> _observers = new List<IObserver<T>>();

    public void AddObserver(IObserver<T> observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver<T> observer)
    {
        _observers.Remove(observer);
    }

    protected void NotifyObservers(T value)
    {
        _observers.ForEach((_observer) =>
        {
            _observer.OnNotify(value);
        });
    }
}