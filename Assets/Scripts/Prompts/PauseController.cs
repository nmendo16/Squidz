using UnityEngine;
using UnityEngine.UI; // Import UI namespace for Image

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenu;
//    public GameObject optionsMenu;
    private bool isPaused = false;

    void Start()
    {
        // Hide the pause menu at the start
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
 //           optionsMenu.SetActive(false);
        }
    }

    void Update()
    {
        // Toggle pause with ESC key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
      
    }

    void TogglePause()
    {
        // Toggle the pause state
        isPaused = !isPaused;   

        // Show or hide the pause menu UI
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(isPaused);
   //         optionsMenu.SetActive(isPaused);
        }

        // Pause or unpause game time
        Time.timeScale = isPaused ? 0 : 1;
    }
}
