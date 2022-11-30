using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCOMTest : MonoBehaviour
{
    private void Start() {
       GetComponent<Rigidbody2D>().centerOfMass = new Vector3(0.20f, -0.15f, 0); 
    }
}
