using UnityEngine;
using UnityEngine.UI;

public class WinEvent : MonoBehaviour
{
    public PlayerHealthSystem BloopHealth; // Reference to Player 1's health system (Bloop)
    public PlayerHealthSystem InkyHealth; // Reference to Player 2's health system (Inky)
    public Image winPrompt; // The UI Image to show the win message

    public Sprite BloopWinSprite; // Sprite for Bloop (Player 1) winning
    public Sprite InkyWinSprite; // Sprite for Inky (Player 2) winning

    void Start()
    {
        winPrompt.gameObject.SetActive(false); // Hide win prompt at the start
    }

    // Call this method from PlayerHealthSystem to check who won
    public void CheckForWin()
    {
        // Check if either player's health is 0
        if (BloopHealth.hp <= 0)
        {
            ShowWinPrompt(2); // Inky wins
        }
        else if (InkyHealth.hp <= 0)
        {
            ShowWinPrompt(1); // Bloop wins
        }
    }

    void ShowWinPrompt(int winningPlayer)
    {
        // Show the win prompt UI
        winPrompt.gameObject.SetActive(true);

        // Set the win prompt sprite based on the winning player
        if (winningPlayer == 1)
        {
            winPrompt.sprite = BloopWinSprite; // Bloop wins
        }
        else
        {
            winPrompt.sprite = InkyWinSprite; // Inky wins
        }

        // Optionally, you can stop the game (pause) here if you like
        Time.timeScale = 0; // Pauses the game
    }
}
