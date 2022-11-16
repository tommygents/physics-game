using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAnimal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        //find mouse position on screen
        Vector2 mousePositionOnScreen = Input.mousePosition;

        //translate that to in-world position, and clamp it
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(
            new Vector2(
                Mathf.Clamp(mousePositionOnScreen.x, 0, Camera.main.pixelWidth),
                Mathf.Clamp(mousePositionOnScreen.y, 0, Camera.main.pixelHeight)
                )
            );

        //move animal to mouse
        transform.position = new Vector3(mousePositionInWorld.x, mousePositionInWorld.y, 0);

    }
}
