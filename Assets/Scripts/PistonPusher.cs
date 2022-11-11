using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonPusher : MonoBehaviour
{
    private Rigidbody2D myRb;
    private float randomPushTimer;

    private void Start() {
        // Set timer for piston launch to random value
        randomPushTimer = Random.Range(1.5f, 5.0f);
        myRb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        randomPushTimer -= Time.deltaTime;
        
        // When timer reaches 0...
        if (randomPushTimer <= 0.0f) {

            // ...apply sudden upward force on the piston head
            myRb.AddForce(Vector2.up * 8.5f, ForceMode2D.Impulse);
            
            // ...and reset piston launch timer
            randomPushTimer = Random.Range(1.5f, 5.0f);
        }
    }
}
