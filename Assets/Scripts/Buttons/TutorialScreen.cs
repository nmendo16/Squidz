using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialScreen : MonoBehaviour
{
    public Button buttReturn;
    public GameObject title;
    //public Image backgroundOverlay;

    void Start()
    {
        //title.SetActive(true);
        //buttQuit.gameObject.SetActive(true);
        //buttQuit.onClick.AddListener(QuitGame);
        ////backgroundOverlay.enabled = false;
        buttReturn.onClick.AddListener(Return);
    }

    void Return()
    {
        SceneManager.LoadScene("MenuScreen");
    }
}
