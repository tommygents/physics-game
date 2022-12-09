using UnityEngine;

public class CheckGameEnd : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Island") {
            gameManager.gameEndCheck = true;
        }
    }
}
