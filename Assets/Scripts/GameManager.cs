using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int score;
    public TextMeshProUGUI scoreText;
    public int numAnimals = 0;
    public int numAnimalsMax = 3;

    [SerializeField] private SpriteRenderer island;
    private float gameTimer;
    
    public bool gameEndCheck;

    private void Start() {
        gameTimer = 120f;
        score = 0;
        gameEndCheck = false;
    }

    private void Update() {
        gameTimer -= Time.deltaTime;
        if (gameTimer <= 0f) {
            gameTimer = 0f;
            if (!gameEndCheck) {
                island.transform.position = new Vector3(island.transform.position.x - 0.003f, 0, 0);
            }
        }
    }

    public void IncrementScore()
    {
        score++;
        Debug.Log(score);
        scoreText.text = score.ToString();  
    }

}
