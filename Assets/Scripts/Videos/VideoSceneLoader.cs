using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoSceneLoader : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string mainMenuSceneName = "MenuScreen";

    void Start()
    {
        videoPlayer.loopPointReached += LoadMainMenuScene;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(mainMenuSceneName);
        }
    }

    void LoadMainMenuScene(VideoPlayer vp)
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
