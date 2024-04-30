using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//Water Icon: Image by Darwin Laganzon from Pixabay

public class Cake : MonoBehaviour
{

    public static int scoreCounter = 0;

    void OnCollisionEnter2D(Collision2D collision) {

        Debug.Log("A collision occurred");
        scoreCounter++;
        Debug.Log("Your score is " + scoreCounter);

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
