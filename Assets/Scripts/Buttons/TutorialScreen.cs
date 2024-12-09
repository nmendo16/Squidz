using UnityEngine;
using UnityEngine.UI;

public class TutorialScreen : MonoBehaviour
{
    public Button buttQuit;
    public GameObject title;
    //public Image backgroundOverlay;

    void Start()
    {
        //title.SetActive(true);
        //buttQuit.gameObject.SetActive(true);
        //buttQuit.onClick.AddListener(QuitGame);
        ////backgroundOverlay.enabled = false;
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
