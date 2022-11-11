using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private void FixedUpdate() {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }
}
