using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("Level1");
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void OpenOptionsMenu()
    {
        //ring.SetActive(false);
        //title.SetActive(false);
        
        optionsMenuPrefab.SetActive(true);
        mainItems.SetActive(false);

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
}
