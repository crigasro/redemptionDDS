using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerState playerstate;
    private int goingState;
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
        goingState = 3; //de momento
    }


    void Update()
    {
        
    }

    public int getGoingState() 
    {
        return goingState;
    }

    public void setGoingState(int gS)
    {
        this.goingState = gS;
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
        int indextoload = actualLevel + 1;
        SceneManager.LoadScene(indextoload);
    }

    public void GiveRandomObjectFromChest()
    {
        //getPlayerState().changeState(getPlayerState().getSlowerState());
        goingState = 1; //gravedad invertida --desde player state se pone a 0 (no bad efect) (?)
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
