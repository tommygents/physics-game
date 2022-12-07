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
    private IslandMover islandScript;
    private float gameTimer;

    private void Start()
    {
        gameTimer = 120f;
        score = 0;
        islandScript = island.GetComponent<IslandMover>();
    }

    private void Update() {
        gameTimer -= Time.deltaTime;
        if (gameTimer <= 0f && !islandScript.reachedEnd) {
            gameTimer = 0f;
            islandScript.reachedEnd = true;
        }
    }

    public void IncrementScore()
    {
        score++;
        Debug.Log(score);
        scoreText.text = score.ToString();  
    }

}
