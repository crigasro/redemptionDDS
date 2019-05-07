using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public Mummy player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Mummy>();
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
