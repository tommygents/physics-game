using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    [SerializeField] private float rotationAmount;
    
    private void FixedUpdate() {
        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0, 0, -rotationAmount);
        }
        else if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0, 0, rotationAmount);
        }
    }
}
