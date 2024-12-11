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

    [SerializeField]
    private Animator player1Animator;
    [SerializeField]
    private Animator player2Animator;

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
            player1Animator.SetBool("win", true);
            Debug.Log("Player1 has " + player1Score + " points");
        }
        else
        {
            player2Score++;
            player2Animator.SetBool("win", true);
            Debug.Log("Player1 has " + player2Score + " points");

        }
        StartCoroutine(ChangeScene());

    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3);

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
            ResetPoints();
            SceneManager.LoadScene("player2Wins");
        }

        else
        {
            ResetPoints();
            SceneManager.LoadScene("player1Wins");
        }

        HealthEventManager.PlayerDied -= AwardPoint;
    }

    public int getRoundNumber()
    {
        return player1Score + player2Score;
    }

    private void ResetPoints()
    {
        player1Score = 0;
        player2Score = 0;
    }

}
