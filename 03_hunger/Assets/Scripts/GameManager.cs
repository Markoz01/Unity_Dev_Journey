using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int score = 0;

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score:" + score);
    }

    private int lives = 3;

    public void LoseLife()
    {
        if (lives > 0)
        {
            lives--;
            Debug.Log("Lives:" + lives);
        }
        else if (lives <= 0)
        {
            Debug.Log("Game Over!");
        }
    }

}
