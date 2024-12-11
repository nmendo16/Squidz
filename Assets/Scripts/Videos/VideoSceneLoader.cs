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

    void LoadMainMenuScene(VideoPlayer vp)
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
