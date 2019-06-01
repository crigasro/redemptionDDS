using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Observer : MonoBehaviour
{
    public enum NotificationType{
        AchivementUnlocked
    }
    public abstract void OnNotify();
}
