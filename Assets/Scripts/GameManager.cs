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


    private void Start()
    {
        score = 0;
    }

    public void IncrementScore()
    {
        score++;
        Debug.Log(score);
        scoreText.text = score.ToString();  
    }

   

}
