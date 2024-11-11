using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{
    private static int player1Score = 0;
    private static int player2Score = 0;
    private static string[] levels = {"Level1", "Level2", "Level3"};

    // Start is called before the first frame update
    void Start()
    {
        HealthEventManager.PlayerDied += AwardPoint;
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    private void AwardPoint(bool isPlayer2)
    {
        if (isPlayer2)
        {
            player1Score++;
            Debug.Log("Player1 has " + player1Score + " points");
        }
        else
        {
            player2Score++;
            Debug.Log("Player1 has " + player2Score + " points");
        }

        if (player1Score < 3 && player2Score < 3)
        {
            string currentLevel = SceneManager.GetActiveScene().name;
            string levelToload = levels[Random.Range(0, levels.Length)];
            while (levelToload == currentLevel)
            {
                levelToload = levels[Random.Range(0, levels.Length)];
            }
            SceneManager.LoadScene(levelToload);
        }

        else if (player1Score < player2Score)
        {
            SceneManager.LoadScene("player2Wins");
        }

        else
        {
            SceneManager.LoadScene("player1Wins");
        }

        HealthEventManager.PlayerDied -= AwardPoint;
    }
}
