using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCreditsVideo : MonoBehaviour
{
    public float delayBeforeLoading = 3f; // Delay in seconds before loading the credits video scene
    public string creditsSceneName = "CreditsVideoScene";

    void Start()
    {
        StartCoroutine(LoadSceneAfterDelay());
    }

    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoading);
        SceneManager.LoadScene(creditsSceneName);
    }
}

