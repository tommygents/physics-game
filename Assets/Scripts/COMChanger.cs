using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COMChanger : MonoBehaviour
{
    [SerializeField] private Vector3 newCenterOfMass;

    private void Start() {
        if (newCenterOfMass != null) {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null) {
                rb.centerOfMass = newCenterOfMass;
            }
        }
    }
}
