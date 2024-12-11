using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public Button buttStart;
    public Button buttQuit;
    public Button buttOptions;
    public GameObject title;//just for visibility
    public GameObject ring;//just for visibility
    public GameObject optionsMenuPrefab; // Prefab for the options menu
    private GameObject optionsMenuInstance; // Instance of the options menu
    public Image backgroundOverlay; // Semi-transparent overlay
    public GameObject mainItems;

    void Start()
    {

        mainItems.SetActive(true);
        //ring.SetActive(true);
        //title.SetActive(true);
        

        //buttStart.gameObject.SetActive(true);
        //buttQuit.gameObject.SetActive(true);
        //buttOptions.gameObject.SetActive(true);

        buttStart.onClick.AddListener(StartGame);
        buttQuit.onClick.AddListener(QuitGame);
        buttOptions.onClick.AddListener(OpenOptionsMenu);

        optionsMenuPrefab.SetActive(false);
        backgroundOverlay.enabled = false; // Ensure overlay is hidden initially
    }

    void StartGame()
    {
        StartCoroutine(DelayScene());
    }

    void QuitGame()
    {
        StartCoroutine (DelayQuit());
    }

    void OpenOptionsMenu()
    {
        StartCoroutine (DelayOptionMenu());

        // Get the OptionsMenu script from the instance and set up the callback
        //OptionsMenu optionsMenuScript = optionsMenuInstance.GetComponent<OptionsMenu>();
        //    optionsMenuScript.onCloseOptions += CloseOptionsMenu;
        
    }
    // Delay Scene Transition for click sound
    IEnumerator DelayScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Level1");
    }
    // Delay Option Menu for click sound
    IEnumerator DelayOptionMenu()
    {
        yield return new WaitForSeconds(0.3f);
        //ring.SetActive(false);
        //title.SetActive(false);
        optionsMenuPrefab.SetActive(true);
        mainItems.SetActive(false);

        //buttStart.gameObject.SetActive(false);
        //buttQuit.gameObject.SetActive(false);
        //buttOptions.gameObject.SetActive(false);
    }
    // Delay Quit Game
    IEnumerator DelayQuit()
    {
        yield return new WaitForSeconds(1.5f);
        Application.Quit();
    }


        //buttStart.gameObject.SetActive(false);
        //buttQuit.gameObject.SetActive(false);
        //buttOptions.gameObject.SetActive(false);

        // Get the OptionsMenu script from the instance and set up the callback
        //OptionsMenu optionsMenuScript = optionsMenuInstance.GetComponent<OptionsMenu>();
            //optionsMenuScript.onCloseOptions += CloseOptionsMenu;

    }

    //void CloseOptionsMenu()
    //{
    //    optionsMenuPrefab.SetActive(false);
    //    backgroundOverlay.enabled = false;
    
    //    buttStart.gameObject.SetActive(true);
    //    buttQuit.gameObject.SetActive(true);
    //    buttOptions.gameObject.SetActive(true);
    
    
    //    ring.SetActive(true);
    //    title.SetActive(true);
    //}

