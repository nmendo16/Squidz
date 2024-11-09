using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    private int player1Score = 0;
    private int player2Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        HealthEventManager.PlayerDied += AwardPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
    }
}
