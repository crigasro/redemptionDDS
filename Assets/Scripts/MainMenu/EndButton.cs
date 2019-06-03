using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButton : MonoBehaviour
{
    public void ClickDie(){
        SceneManager.LoadScene(8);
    }

    public void ClickLive(){
        SceneManager.LoadScene(9);
    }

    public void Return() {
        SceneManager.LoadScene(0);
    }

    public void Continue() {
        SceneManager.LoadScene(10);
    }
}
