using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //[SerializeField] [Range(100, 500)] private float speed = 175f;
    [SerializeField] [Range(100, 500)] private float speed = 300f;
    [SerializeField] [Range(100, 500)] private float jumpForce = 150f;
    [SerializeField] [Range(0.01f, 0.5f)] private float movementSmoothing = 0.1f;
    [SerializeField] private LayerMask groundLayerMask;

    public bool grounded { get; private set; }
    public bool isActive { get; private set; }

    private float direction;
    
    private Animator animator;  // Instance created in Start()
    private Rigidbody2D rb; // Instance created in Start()
    private Transform groundCheck; // Instance created in Start()
    private Vector3 targetVelocity;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");

        isActive = true;  // TEMPORALMENTE
    }


    private void Update()
    {

    }


    //FixedUpdate porque es mejor para movimientos
    private void FixedUpdate()
    {
        checkGround();

        if (isActive)
            Move();
            Jump();
    }

    protected void Move()
    {
        direction = Input.GetAxis("Horizontal");
        //if (direction < 0) {
          //  targetVelocity = new Vector2(-1f * speed * Time.deltaTime, rb.velocity.y);
        //} else if (direction > 0) {
          //  targetVelocity = new Vector2(1f * speed * Time.deltaTime, rb.velocity.y);
        //} else if (direction == 0) {
        targetVelocity = new Vector2(direction * speed * Time.deltaTime, velocity.y);
        //}
        rb.velocity = targetVelocity;
        //Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);

        UpdateAnimatorVariabes();
    }

    private void Jump()
    {
        bool canJump = Input.GetKey(KeyCode.Space) && grounded;
        if (canJump)
        {
            Vector2 jumpMovement = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
            rb.AddForce(jumpMovement, ForceMode2D.Impulse);
        }
    }

    private void UpdateAnimatorVariabes()
    {
        //animator.SetFloat("x", this.direction.x);
        //animator.SetBool("isMoving", this.direction != Vector2.zero);
    }
    
    private void checkGround()
    {
        grounded = false;

        Collider2D[] nearColliders = Physics2D.OverlapCircleAll(this.groundCheck.position, 0.2f, this.groundLayerMask);

        foreach(Collider2D collider in nearColliders) {
        
            if (collider.gameObject != gameObject)
            {
                grounded = true;
            }
        }
    }
}
