using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movementx;
    [SerializeField] float moveSpeed;




    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private Vector2 groundCheckSize;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded = false;


    private bool isJumping = false;
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpSelectionSpeed;
    private float jumpMax = 10;
    public Transform direction;
    
    [SerializeField] GameObject aimPivot;
    [SerializeField] float aimRotationSpeed;
    private float aimAngleMin;
    private float aimAngleMax;

    [SerializeField] TextMeshProUGUI jumpPowerUI;


    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // gets rigidbody on player
    }

    // Update is called once per frame
    
    void Update()
    {
        GroundCheck();
        movementx = Input.GetAxis("Horizontal"); //old input system
        jump();
        jumpUI();
    }

    private void FixedUpdate()
    {
        
        //Movement();
    }



    private void Movement()
    {
       
        if(isGrounded && !isJumping) // if player is on the ground and not jumping, the player can move
        {
            rb.linearVelocity = new Vector2(movementx * moveSpeed, rb.linearVelocity.y); 
        }
        
       
    }





    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isJumping)//when the space is pressed
        {
            aimPivot.transform.rotation = Quaternion.Euler(0f, 0f, 0f); // reset aim to 0,0,0
            isJumping = true;
            jumpPower = 0f; // reset jump power
        }

            
        if (Input.GetKey(KeyCode.Space) && isGrounded && isJumping)//when the space is held down
        {
            
            jumpPower = Mathf.PingPong(Time.time * jumpSelectionSpeed, jumpMax)* 5;//the jump power goes back and forth between the 0 and jump max
            

            if(Input.GetKey(KeyCode.A))
            {
                aimPivot.transform.Rotate(0, 0, aimRotationSpeed);//aim moves left multiplied by aim rotation speed
            }
            else if (Input.GetKey(KeyCode.D))
            {
                aimPivot.transform.Rotate(0, 0, -aimRotationSpeed);//aim moves right multiplied by aim rotation speed
            }
            
        }



        if (Input.GetKeyUp(KeyCode.Space) && isGrounded && isJumping)//when space is released
        {
            

            Vector2 jumpDirection = (direction.position - transform.position).normalized;//gets the the jump direction 
            rb.linearVelocity = Vector2.zero;//reset the players velocity

            rb.AddForce(jumpDirection * jumpPower, ForceMode2D.Impulse);//add force to player in jump direction multiplied by jump power
            isJumping = false;//stop jumping
            jumpPower = 0f;//resets jump power
        }
    }







    private void GroundCheck()//check is player is touching the  ground
    {
        if (Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0f, groundLayer))// creates a box that checks if the player is touching the ground
        {
            isGrounded = true;//The player is touching the ground
        }
        else
        {
            isGrounded = false;//The player is not touching the ground 
        }
        

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheckPoint.position, groundCheckSize);//visulises the gound check box for debuging 
    }





    void jumpUI()
    {
        jumpPowerUI.text = ("Jump Power :" + jumpPower);//displays the jump power to the player - will switch to a bar rather than text
    }
}
