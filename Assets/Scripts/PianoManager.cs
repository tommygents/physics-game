using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoManager : MonoBehaviour
{

    [SerializeField] private float pushForce = 5.5f;

    private List<Rigidbody2D> pianoKeys;

    private void Start() {
        pianoKeys = new List<Rigidbody2D>();
        foreach (Transform child in transform) {
            pianoKeys.Add(child.GetComponent<Rigidbody2D>());
        }
    }

    private void OnGUI() {
        if (Input.anyKeyDown) {
            Debug.Log(Event.current);
        }
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Q)) {
            WaveMaker(0);
        }        
        if (Input.GetKey(KeyCode.W)) {
            WaveMaker(1);
        }
        if (Input.GetKey(KeyCode.E)) {
            WaveMaker(2);
        }
        if (Input.GetKey(KeyCode.I)) {
            WaveMaker(3);
        }
        if (Input.GetKey(KeyCode.O)) {
            WaveMaker(4);
        }
        if (Input.GetKey(KeyCode.P)) {
            WaveMaker(5);
        }
    }

    // Makes a wave on a first set of 3 piano keys and its corresponding second set, specified by the piano key (child) index relative to the parent piano manager object
    private void WaveMaker(int childIndex) {

        /*
        if (childIndex > 0) {
            pianoKeys[childIndex - 1].AddForce(Vector2.up * (pushForce / 2), ForceMode2D.Impulse);
        }
        */
        pianoKeys[childIndex].AddForce(Vector2.up * pushForce, ForceMode2D.Impulse);
        /*
        if (childIndex < (pianoKeys.Count - 1)) {
            pianoKeys[childIndex + 1].AddForce(Vector2.up * (pushForce / 2), ForceMode2D.Impulse);
        }
        */
        if ((childIndex + 6) <= (pianoKeys.Count - 1)) {
            WaveMaker(childIndex + 6);
        }
    }
}
