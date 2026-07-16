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
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    
    void Update()
    {
        GroundCheck();
        movementx = Input.GetAxis("Horizontal");
        jump();
        jumpUI();
    }

    private void FixedUpdate()
    {
        
        //Movement();
    }



    private void Movement()
    {
       
        if(isGrounded && !isJumping)
        {
            rb.linearVelocity = new Vector2(movementx * moveSpeed, rb.linearVelocity.y);
        }
        
       
    }





    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isJumping)
        {
            aimPivot.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            isJumping = true;
            jumpPower = 0f;
        }

            
        if (Input.GetKey(KeyCode.Space) && isGrounded && isJumping)
        {
            
            jumpPower = Mathf.PingPong(Time.time * jumpSelectionSpeed, jumpMax)* 5;
            

            if(Input.GetKey(KeyCode.A))
            {
                aimPivot.transform.Rotate(0, 0, aimRotationSpeed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                aimPivot.transform.Rotate(0, 0, -aimRotationSpeed);
            }
            Debug.Log("Move aim");
        }



        if (Input.GetKeyUp(KeyCode.Space) && isGrounded && isJumping)
        {
            //float radians = aimPivot.transform.rotation.z * Mathf.Deg2Rad;
            //Vector2 jumpDirection = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
            //Debug.Log(jumpDirection);

            Vector2 jumpDirection = (direction.position - transform.position).normalized;
            rb.linearVelocity = Vector2.zero;

            rb.AddForce(jumpDirection * jumpPower, ForceMode2D.Impulse);
            isJumping = false;
            jumpPower = 0f;
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





    void jumpUI()
    {
        jumpPowerUI.text = ("Jump Power :" + jumpPower);
    }
}
