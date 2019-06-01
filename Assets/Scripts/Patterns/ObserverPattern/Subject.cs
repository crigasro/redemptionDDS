using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
  // Subject = objetos observables. A los que vamos a mirar para ver qué pasa con ellos
  // y para que notifiquen los cambios.
  private List<Observer> _observers = new List<Observer>();

  public void AttachObserver(Observer observer)
  {
    _observers.Add(observer);
  }

  public void DetachObserver(Observer observer)
  {
    _observers.Remove(observer);
  }

  public void NotifyObserver(Object obj, Event ev)
  {
    foreach (Observer o in _observers) { o.OnNotify(obj, ev); }
  }
}
