using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] [Range(100, 500)] private float speed = 175f;
    [SerializeField] [Range(100, 500)] private float maxSpeed = 300f;
    [SerializeField] [Range(100, 500)] private float jumpForce = 300f;
    [SerializeField] [Range(0.01f, 0.5f)] private float movementSmoothing = 0.1f;
    [SerializeField] private LayerMask groundLayerMask;

    public bool grounded { get; private set; }
    public bool isActive { get; private set; }

    private Vector2 direction;
    private Vector3 velocity = Vector3.zero;
    
    private Animator animator;  // Instance created in Start()
    private Rigidbody2D rb; // Instance created in Start()
    private Transform groundCheck; // Instance created in Start()

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");

        isActive = true;  // TEMPORALMENTE
    }


    private void Update()
    {
        this.direction = Vector2.zero;

        GetInputRight();
        GetInputLeft();
        GetInputJump();
    }


    //FixedUpdate porque es mejor para movimientos
    private void FixedUpdate()
    {
        checkGround();

        if (isActive)
            Move();
    }


    protected void Move()
    {
        Vector3 targetVelocity = new Vector2(this.direction.x * maxSpeed * Time.fixedDeltaTime * 10, rb.velocity.y);

        this.rb.velocity = Vector3.Lerp(velocity, targetVelocity, movementSmoothing);
        velocity = this.rb.velocity; 
       // Debug.Log("Direction: " + this.direction);
        // Debug.Log("Grounded: " + this.grounded);

        if (this.direction.y > 0 && this.grounded)
        {
            Debug.Log("ADDING FORCE!!!");
            this.rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            this.grounded = false;
        }
        UpdateAnimatorVariabes();
    }


    private void UpdateAnimatorVariabes()
    {
        animator.SetFloat("x", this.direction.x);
        animator.SetBool("isMoving", this.direction != Vector2.zero);
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

    private void GetInputRight()
    {
        bool keyPressed = (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow));

        if (keyPressed)
        {
            Debug.Log("DERECHAA");
            direction += Vector2.right;
        }

    }

    private void GetInputLeft()
    {
        bool keyPressed = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        if (keyPressed)
        {
            this.direction += Vector2.left;
        }
    }

    private void GetInputJump()
    {
        bool condition = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) && grounded;
        if (condition)
        {
            this.direction += Vector2.up;
        }
    }
}
