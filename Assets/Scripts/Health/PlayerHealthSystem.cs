using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import UI namespace
using UnityEngine.SceneManagement; 

public class PlayerHealthSystem : MonoBehaviour
{
    public float hp = 100f;
    [SerializeField]
    private NewPlayerMovement player;
    [SerializeField]
    private Animator animator;
    private bool playerDied = false;

    // Array to hold the different health sprites
    public Sprite[] healthSprites; // Assign in Inspector (100, 80, 60, 40, 20, empty)
    public Image healthImage; // Reference to the UI Image component

    // Reference to WinEvent (the script handling win/loss events)
    public WinEvent winEventSystem;

    // Reference to the health bar material
    public Material healthBarMaterial;
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetHealthBar(); // Reset health to full when the new scene is loaded
        ResetHealthBarColor(); // Reset the health bar color to green

    }
    private void Start()
    {
        ResetHealthBar(); // Initialize health to full at the start of the scene
        UpdateHealthSprite(); // Initialize health sprite at start
        ResetHealthBarColor();
    }

    public void OnHit(float damage)
    {
        hp -= damage;
        Debug.Log("HP = " + hp);

        StartCoroutine(PlayHitAnimationCrutine());

        UpdateHealthBar(); // Update shader health bar
        UpdateHealthSprite(); // Update UI sprite

        // Check if the player's health has reached 0 or below
        if (hp <= 0 && playerDied == false)
        {
            playerDied = true;
            PlayerDied();
        }
    }

    // Method to reset the health bar and shader at the start of the scene
    private void ResetHealthBar()
    {
        hp = 100f; // Reset health to full
        UpdateHealthBar(); // Update shader to reflect full health
    }

    // Method to update the shader's health bar based on current health
    private void UpdateHealthBar()
    {
        if (healthBarMaterial != null)
        {
            float normalizedHealth = hp / 100f; // Normalize health (0-1)
            Debug.Log("Updating Health Bar: " + normalizedHealth); // Debug log to check normalized value
            healthBarMaterial.SetFloat("_Health", normalizedHealth); // Update shader
        }
        else
        {
            Debug.LogWarning("Health bar material is not assigned.");
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

    public void PlayerDied()
    {
        winEventSystem.CheckForWin(); // Assuming CheckForWin() handles the win condition
        animator.SetBool("lose", true);
        HealthEventManager.PlayerDiedEvent(player.GetPlayerNumber());

        // Change scene or trigger game-over logic
        StartCoroutine(ChangeSceneAfterDelay());
    }

    IEnumerator ChangeSceneAfterDelay()
    {
        yield return new WaitForSeconds(3); // Wait for animation or effects
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene"); // Replace with your scene name
    }

    IEnumerator PlayHitAnimationCrutine()
    {
        animator.SetBool("damage", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("damage", false);
    }

    // Method to reset the health bar's color or material at the start of a new scene
    private void ResetHealthBarColor()
    {
        if (healthBarMaterial != null)
        {
            // Reset the health to full (green color) in the shader
            healthBarMaterial.SetFloat("_Health", 1f); // 1f means full health (green)
        }
        else
        {
            Debug.LogWarning("Health bar material is not assigned.");
        }
    }

}
