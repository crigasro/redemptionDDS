using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
  // Subject = objetos observables. A los que vamos a mirar para ver qué pasa con ellos
  // y para que notifiquen los cambios.
  private List<Observer> _observers = new List<Observer>();

  protected static string CompletedPuzzle = "COMPLETED_PUZZLE";


  public void AttachObserver(Observer observer)
  {
    if(_observers.Contains(observer) == false)
      _observers.Add(observer);
  }

  public void DetachObserver(Observer observer)
  {
    _observers.Remove(observer);
  }

  public void NotifyObserver(NotifType nt, bool extraInfo)
  {
    // No creo que esta sea la mejor forma de hacer ( me refiero a los parametros que le paso )
    foreach (Observer o in _observers) { o.OnNotify(gameObject, nt, extraInfo); }
  }
}
