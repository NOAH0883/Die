using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Variables")]
    private Rigidbody2D rb;
    private float movementx;
    [SerializeField] float moveSpeed;

    [Header("Ground check")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private Vector2 groundCheckSize;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded = false;

    [Header("Jumping")]
    private bool isJumping = false;
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpSelectionSpeed;
    private float jumpMax = 10;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementx = Input.GetAxisRaw("Horizontal");
        GroundCheck();
        StartJump();
    }

    private void FixedUpdate()
    {
        Movement();
        
    }

    private void Movement()
    {
        if (!isJumping)
        {
            rb.linearVelocity = new Vector2(movementx * moveSpeed, rb.linearVelocity.y);
        }
        
    }

   

    private void StartJump()
    {

        //if (Input.GetKey(KeyCode.Space) && isGrounded)
       // {
           // isJumping = true;
            //jumpPower = Mathf.PingPong(Time.time * jumpSelectionSpeed, jumpMax)* 2;   
        //}
        
     

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpPower = 10f;
            float randomAngle = Random.Range(0f, 180f);
            float radians = randomAngle * Mathf.Deg2Rad;
            Vector2 randomDirection = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
            Debug.Log(randomDirection);

            rb.AddRelativeForce(randomDirection * jumpPower, ForceMode2D.Impulse);
            
            isJumping = false;
        }

    }



    private void GroundCheck()
    {
        if (Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0f, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        Debug.Log(isGrounded);
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheckPoint.position, groundCheckSize);
    }
}

