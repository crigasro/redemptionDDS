using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public PlayerState playerstate;
    public Transform firePoint;
    public GameObject fireball;
    public GameObject iceball;
    public bool icePower = false;
    public bool firePower = false;

    void Awake () {
        MakeSingleton();
    }
    
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public PlayerState getPlayerState() 
    {
        // Asociar PlayerState al Jugador y después arrastrar el jugador a playerstate de aqui
        return playerstate;
    }

    public void LoadScenario(int buildSettingsIndex) {
        SceneManager.LoadScene(buildSettingsIndex);
    }

    public void LoadDoorScenario(int actualLevel) {
        SceneManager.LoadScene(actualLevel + 1);
    }

    public void GiveRandomObjectFromChest()
    {
        //getPlayerState().changeState(getPlayerState().getSlowerState());
    }
    
    public void giveFire() {
        firePower = true;
        Debug.Log("giveFire() -- firePower is: " + firePower);
    }

    public void giveIce() {
        icePower = true;
        Debug.Log("giveIce() -- icePower is: " + icePower);
    }
    protected void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
