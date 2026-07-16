using System.Runtime.CompilerServices;
using UnityEngine;

public class bird_movement : MonoBehaviour

    
{
   
    [SerializeField] float moveSpeed;
    [SerializeField] float border = 10;
    
    bool moveLeft;
    SpriteRenderer spriteRenderer;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        if(moveLeft)
        {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }
        else if (!moveLeft)
        {
            transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;

        }


        if (transform.position.x > border)
        {
            spriteRenderer.flipX = false;
            moveLeft = true;
            
        }
        else if (transform.position.x < -border)
        {
            moveLeft = false;
            spriteRenderer.flipX = true;
        }

        //if (transform.position.x > rightBorder)
        // {


        //}

    }
}
