using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerState playerstate;

    public enum PlayerStates { NoBadState, ControlInvState, GravityInvState, SlowedState }
    private PlayerStates goingState;

    [HideInInspector]
    public Transform firePoint;

    public bool icePower = false;
    public bool firePower = false;
    public bool lifePower = false;

    void Awake () {
        MakeSingleton();
    }
    
    void Start()
    {
        getFirePoint();
        goingState = PlayerStates.NoBadState;
    }

    void Update()
    {
        
    }

    public PlayerStates getGoingState() 
    {
        return goingState;
    }

    public void setGoingState(PlayerStates gS)
    {
        this.goingState = gS;
    }

    public PlayerState getPlayerState() 
    {
        // Asociar PlayerState al Jugador y después arrastrar el jugador a playerstate de aqui
        return playerstate;
    }

    public Transform getFirePoint()
    {
        if (firePoint == null)
            firePoint = GameObject.FindGameObjectWithTag("Player").transform.Find("FirePoint");

        return firePoint;
    }


    public void LoadNextScenario(int actualLevel) {
        int indextoload = actualLevel + 1;
        SceneManager.LoadScene(indextoload);
    }

    public void GiveRandomState()
    {
        setGoingState((PlayerStates) Random.Range(0,4));
    }
    
    public void giveFire() {
        firePower = true;
        Debug.Log("giveFire() -- firePower is: " + firePower);
    }

    public void giveIce()
    {
        icePower = true;
        Debug.Log("giveIce() -- icePower is: " + icePower);
    }

    public void giveLifePower()
    {
        lifePower = true;
        Debug.Log("giveLifePower() -- lifePower is: " + lifePower);
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

    public void resetPowers() {
        icePower  = false;
        firePower = false;
        lifePower = false;
    }
}
