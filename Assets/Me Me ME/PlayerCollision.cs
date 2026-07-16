using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{


    Rigidbody2D rb;
    [SerializeField] float KnockBackForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Enemy"))
        {
            Transform enemyPos = collision.transform;
            Vector2 direction = (transform.position - enemyPos.position).normalized; 
            rb.AddForce(direction * KnockBackForce, ForceMode2D.Impulse);
            Debug.Log("HitEnemy");
        }
    }
}
