using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Parent container object for all water drops
    [SerializeField] private GameObject waterWrapper;

    private float waterShotTimer;

    private void Start()
    {
        // Set timer for water geyser burst
        waterShotTimer = 0.2f;
    }

    private void FixedUpdate() {
        waterShotTimer -= Time.deltaTime;

        // Launch water upward when timer runs out, then reset timer
        if (waterShotTimer <= 0.0f) {
            WaterRocket();
            waterShotTimer = 0.2f;
        }
    }

    // Sends a random water droplet upward with great force
    private void WaterRocket() {

        // Grab a random drop in the parent water "container" object...
        GameObject currentDrop = waterWrapper.transform.GetChild(Random.Range(0, waterWrapper.transform.childCount)).gameObject;

        // ...and apply sudden upward force to it
        currentDrop.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 150, ForceMode2D.Impulse);
    }
}
