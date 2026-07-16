using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cam.transform.position = this.transform.position;
        }
    }
    
}
