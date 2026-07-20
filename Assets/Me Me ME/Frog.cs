using UnityEngine;

public class Frog : MonoBehaviour
{
    //GameObject hitObj;
    Rigidbody2D HitObjRb;
    public float frogForce;
    public bool isLeft;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           // hitObj = collision.gameObject;
            HitObjRb = collision.rigidbody;
            
            if(!isLeft)
            {
                HitObjRb.AddForce(Vector2.left * frogForce, ForceMode2D.Impulse);
                HitObjRb.AddForce(Vector2.up * frogForce, ForceMode2D.Impulse);
            }
            else
            {
                HitObjRb.AddForce(Vector2.right * frogForce, ForceMode2D.Impulse);
            }
            



        }
    }
    
}
