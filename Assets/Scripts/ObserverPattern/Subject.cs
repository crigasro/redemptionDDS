using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    private List<Observer> _observers = new List<Observer>();

    public void AttachObserver(Observer observer)
    {
      _observers.Add(observer);
    }

    public void DetachObserver(Observer observer)
    {
      _observers.Remove(observer);
    }

    public void NotifyObserver()
    {
      foreach (Observer o in _observers) { o.OnNotify(); }
    }
}
