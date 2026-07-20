using UnityEngine;

public class Frog : MonoBehaviour
{
    //GameObject hitObj;
    Rigidbody2D HitObjRb;
    public float frogForceX;
    public float frogForceY;
    public bool isLeft;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           // hitObj = collision.gameObject;
            HitObjRb = collision.rigidbody;
            
            if(!isLeft)
            {
                HitObjRb.AddForce(Vector2.left * frogForceX, ForceMode2D.Impulse);
                HitObjRb.AddForce(Vector2.up * frogForceY, ForceMode2D.Impulse);
            }
            else
            {
                HitObjRb.AddForce(Vector2.right * frogForceX, ForceMode2D.Impulse);
                HitObjRb.AddForce(Vector2.up * frogForceY, ForceMode2D.Impulse);
            }
            



        }
    }
    
}
