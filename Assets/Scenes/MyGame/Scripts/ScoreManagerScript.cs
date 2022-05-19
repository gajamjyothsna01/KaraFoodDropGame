using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    public Text scoreText;
    int score = 0;
    public void Score(int scoreValue)
    {
        score = score + scoreValue;
        Debug.Log("Player Score : " + score);
        scoreText.text = score.ToString();

    }
}
