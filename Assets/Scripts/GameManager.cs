using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerState playerstate;


    
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
}
