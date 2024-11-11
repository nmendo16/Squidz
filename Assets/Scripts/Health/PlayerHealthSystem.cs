using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import UI namespace

public class PlayerHealthSystem : MonoBehaviour
{
    public float hp = 100f;
    [SerializeField]
    private NewPlayerMovement player;

    // Array to hold the different health sprites
    public Sprite[] healthSprites; // Assign in Inspector (100, 80, 60, 40, 20, empty)
    public Image healthImage; // Reference to the UI Image component

    // Reference to WinEvent (the script handling win/loss events)
    public WinEvent winEventSystem;

    private void Start()
    {
        UpdateHealthSprite(); // Initialize health sprite at start
    }

    public void OnHit(float damage)
    {
        hp -= damage;
        Debug.Log("HP = " + hp);

        UpdateHealthSprite();

        // Check if the player's health has reached 0 or below
        if (hp <= 0)
        {
            
            // Call the win event to determine the winner
            StartCoroutine(PlayerDiedCorutine());
            // Call the win event from WinEvent script to check who won
            


            // Optionally, you can stop further health updates or handle death logic here
        }
    }

    // Method to update the health sprite based on current health
    private void UpdateHealthSprite()
    {
        // Ensure health doesn't go below 0
        hp = Mathf.Max(hp, 0f);

        // Calculate which sprite to display based on the player's health
        int spriteIndex = Mathf.FloorToInt(hp / 20); // 100% -> 5, 80% -> 4, ..., 0% -> 0

        // Prevent the index from going out of bounds (0-5 for health percentages 100% to 0%)
        spriteIndex = Mathf.Clamp(spriteIndex, 0, healthSprites.Length - 1);

        if (hp < 0)
        {
            hp = 0;
        }
        // Update the sprite based on health
        healthImage.sprite = healthSprites[spriteIndex];

    }

    IEnumerator PlayerDiedCorutine()
    {
        winEventSystem.CheckForWin(); // Assuming CheckForWin() handles the win condition
        yield return new WaitForSeconds(3);
        HealthEventManager.PlayerDiedEvent(player.GetPlayerNumber());
    }

}
