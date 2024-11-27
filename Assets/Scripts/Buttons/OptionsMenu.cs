using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Button backButton;
    public Button soundToggleButton;
    public Button quitPromptButton;
    public GameObject quitPrompt; // "Are you sure?" prompt
    public Button quitYesButton;
    public Button quitNoButton;

    //add reset game -- this prompts, THIS ERASES ALL PROGRESS OF YOUR BATTLE, do you wish to proceed? restart | cancel
    //add ABOUT SQUIDZ with GUNZ --static pages of instructions/controls/tutorial, story, credits

    private bool soundOn = true;

    // Define an event to communicate with the MainMenu script
    public delegate void CloseOptionsAction();
    //public event CloseOptionsAction onCloseOptions;

    void Start()
    {
        backButton.gameObject.SetActive(true);
        soundToggleButton.gameObject.SetActive(true);
        quitPromptButton.gameObject.SetActive(true);

        backButton.onClick.AddListener(CloseOptions);
        soundToggleButton.onClick.AddListener(ToggleSound);
        quitPromptButton.onClick.AddListener(ShowQuitPrompt);

        quitYesButton.gameObject.SetActive(false);
        quitNoButton.gameObject.SetActive(false);

        quitPrompt.SetActive(false); // Ensure quit prompt is hidden initially
    }

    void ToggleSound()
    {
        soundOn = !soundOn;
        soundToggleButton.GetComponentInChildren<Text>().text = soundOn ? "Sound ON" : "Sound OFF";
        // Optional: Add sound toggle functionality here
    }

    void ShowQuitPrompt()
    {
        quitPrompt.SetActive(true);

        // Disable other buttons when "Are you sure?" prompt is visible
        backButton.gameObject.SetActive(false);
        soundToggleButton.gameObject.SetActive(false);
        quitPromptButton.gameObject.SetActive(false);

        //show yes and no
        quitYesButton.gameObject.SetActive(true);
        quitNoButton.gameObject.SetActive(true);
        quitYesButton.onClick.AddListener(QuitGame);
        quitNoButton.onClick.AddListener(HideQuitPrompt);
    }

    void HideQuitPrompt()
    {
        quitPrompt.SetActive(false);

        // Re-enable other buttons when "Are you sure?" prompt is hidden
        backButton.gameObject.SetActive(true);
        soundToggleButton.gameObject.SetActive(true);
        quitPromptButton.gameObject.SetActive(true);

        quitYesButton.gameObject.SetActive(false);
        quitNoButton.gameObject.SetActive(false);
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void CloseOptions()
    {
        // loads the homepage
        SceneManager.LoadScene("MenuScreen");
    }

       
} 
