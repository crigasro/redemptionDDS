using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    /*
    private string _chestState;
    public string ChestState {
        get {return _chestState; }
        set { _chestState = value; }
    }
     */

    private Animator animChest;

    void Start() {
        animChest = GetComponent<Animator>();
    }
    /*
    void Update() {
        if(Input.GetKeyDown(KeyCode.E))
        {
            animChest.SetBool("chestIsOpen", true);
            //Debug.Log("Has precionado la tecla E porque si");
        }
    }
     */

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") ){
            OpenChest();
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        OpenChest();
    }

    private void OpenChest() {
        if(Input.GetKeyDown(KeyCode.E)) {
            animChest.SetBool("chestIsOpen", true);
            //GameManager.instance.GiveRandomObjectFromChest();
        }
    }
}
