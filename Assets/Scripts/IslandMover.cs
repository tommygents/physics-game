using UnityEngine;

public class IslandMover : MonoBehaviour
{
    public bool reachedEnd;

    private void Start() {
        reachedEnd = false;
    }

    private void Update() {
        if (reachedEnd) {
            transform.position.x -= 4;
        }
    }
}
