using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoManager : MonoBehaviour
{
    private void Start() {

    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8.5f, ForceMode2D.Impulse);
        }        
        if (Input.GetKeyDown(KeyCode.W)) {
            transform.GetChild(1).GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8.5f, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            transform.GetChild(2).GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8.5f, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            transform.GetChild(3).GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8.5f, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            transform.GetChild(4).GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8.5f, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            transform.GetChild(5).GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8.5f, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            transform.GetChild(6).GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8.5f, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.F)) {
            transform.GetChild(7).GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8.5f, ForceMode2D.Impulse);
        }
    }
}
