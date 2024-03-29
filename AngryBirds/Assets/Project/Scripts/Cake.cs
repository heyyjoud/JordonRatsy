using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {

        Debug.Log("A collision occurred");

        Collider2D colliderHit = collision.collider;

        if (colliderHit.gameObject.CompareTag("Point1"))
        {
            Debug.Log("Point1");
        }
        else if (colliderHit.gameObject.CompareTag("Point2"))
        {
            Debug.Log("Point2");
        }
        else if (colliderHit.gameObject.CompareTag("Point3"))
        {
            Debug.Log("Point3");
        }

    }
}
