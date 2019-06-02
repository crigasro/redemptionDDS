using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorManagement : Observer
{
    public Animator animDoor;
    public GameObject[] leversObj;
    public Lever[] levers;
    private bool openDoor = false;
    private bool[] correctCombination = new bool[] {false, true, true};
    private bool[] playerCombination = new bool[3];

    void Start()
    {
        animDoor = GetComponent<Animator>();
        foreach(var lev in levers){
            lev.AttachObserver(this);
        }
    }

    public override void OnNotify(GameObject go, NotifType nt, bool leverstatus)
    {
        if(nt.Equals(NotifType.ActivatedDoor))
        {
            ManageLeverNotification(go, leverstatus);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && openDoor) {
            GameManager.instance.LoadNextScenario(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ManageLeverNotification(GameObject go, bool leverstatus)
    {
        for(int i = 0; i < 3; i++)
        {
            if(go == leversObj[i])
            {
                playerCombination[i] = leverstatus;
            }
        }
        TestCorrectCombination();
    }

    public void TestCorrectCombination()
    {
        bool isCorrect = true;
        for(int i = 0; i < 3; i++){
            if(playerCombination[i] != correctCombination[i])
            {
                isCorrect = false; return;
            }
        }
        if(isCorrect)
        {
            animDoor.SetBool("openDoor", true);
            openDoor = true;
        }
    }
}
