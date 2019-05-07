using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mummy : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;
    public CharacterController player;

    public float playerSpeed = 0.1f;

    public Animator animator;

    public bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<CharacterController>();
        playerSpeed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
    }

    private void FixedUpdate() 
    {
        player.Move(new Vector3(horizontalMove, 0f, verticalMove) * playerSpeed);
        animator.SetBool("IsMoving", player.velocity.magnitude > 0.1);
    }
}
