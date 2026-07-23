using TMPro;
using Unity.VisualScripting;
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
    private bool increaseJump;
    public Transform direction;
    

    [SerializeField] GameObject aimPivot;
    [SerializeField] float aimRotationSpeed;
    [SerializeField] float jumpAngleClamp;
    [SerializeField] float currentAngleRotation;


    [SerializeField] TextMeshProUGUI jumpPowerUI;



    private Animator ani;


    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // gets rigidbody on player
        ani = GetComponentInChildren<Animator>(); // gets animatior controller on player - fish visual
        
    }


    void Update()
    {
        movementx = Input.GetAxis("Horizontal"); //old input system
        GroundCheck(); // calls Ground check function
        jump(); // calls jump function
        jumpUI();// calls jumpUi function
        FishAnimations(); // calls fishAnimation function
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
            
            isJumping = true;// tells script that the player is jumping
            jumpPower = 0f; // reset jump power
            currentAngleRotation = 0;//reset jump angle
        }
        
            
        if (Input.GetKey(KeyCode.Space) && isGrounded && isJumping)//when the space is held down
        {
            //jumpPower = Mathf.PingPong(jumpSelectionSpeed * Time.time, jumpMax)* 7;//the jump power goes back and forth between the 0 and jump max
            UpandDown(); // call function to incease and decerease jump power
            JumpAim(); // falls the fuction to aim the fish
        }



        if (Input.GetKeyUp(KeyCode.Space) && isGrounded && isJumping)//when space is released
        {
            

            Vector2 jumpDirection = (direction.position - transform.position).normalized;//gets the the jump direction 
            rb.linearVelocity = Vector2.zero;//reset the players velocity


            rb.AddForce(jumpDirection * jumpPower * 6, ForceMode2D.Impulse);//add force to player in jump direction multiplied by jump power
            isJumping = false;//stop jumping
            jumpPower = 0f;//resets jump power
            currentAngleRotation = 0;//reset aim rotation
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

   


    void UpandDown()//ping pong number for jump
    {
        if(jumpPower >= jumpMax)
        {
            increaseJump = false;
        }
        else if (jumpPower <=0)
        {
            increaseJump = true;
        }

        if (increaseJump)
        {
            jumpPower += jumpSelectionSpeed * Time.deltaTime;
        }
        else
        {
            jumpPower -= jumpSelectionSpeed * Time.deltaTime;
        }
        
        //float number increase 
        //if number is greater than max 
        //decrease number
        //if number is less than 0
        //increase number
    }


    void JumpAim()
    {

        //float rotationSpeed
        //float rotationClamp
        //float currentRotation 

        //Horizontal input same as movement
        //change currentRotation by Horizontal input
        //clamp currentRotation by rotation clamp float

        //aimPivot.transform.LocalEulerAngles with current rotation float

        //use currentRotationFloat to change the fish animation


        float aimMovement = Input.GetAxis("Horizontal") * aimRotationSpeed * Time.deltaTime; //old input system
        currentAngleRotation -= aimMovement; // increase currentAngleRotation by aimMovement
        currentAngleRotation = Mathf.Clamp(currentAngleRotation, -jumpAngleClamp, jumpAngleClamp);// makes it so the player can't rotate past a given angle
        aimPivot.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, currentAngleRotation);// set the aimpivots rotation to the currentAngleRotation

    }



    void FishAnimations()
    {
        
        if (currentAngleRotation < 0)
        {
            Debug.Log("turn right");
            ani.SetBool("TurnLeft", false);
            ani.SetBool("TurnRight", true);
            
        }
        if (currentAngleRotation > 0)
        {
            Debug.Log("turn");
            ani.SetBool("TurnRight", false);
            ani.SetBool("TurnLeft", true);
        }


        //void FishAnimation()

        //if player is grounded and not jumping - set animation to idle

        //if player is jumping
        //if currentAngleRotation is greater than 0 - play right aim animation 
        //if currentAngleRotation is less than 0  - play right aim animation

        //if player is not grounded and not jumping - set animation to flop

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
