using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public PlayerController player;
    public IndianController indian;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<PlayerController>();
        indian = gameObject.GetComponent<IndianController>();
    }

    void OnTriggerEntered2D(Collider2D col)
    {
        player.grounded = true;

    }
    void OnTriggerStay2D(Collider2D col)
    {
        player.grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        player.grounded = false;
    }


}
