
using System.Collections;
using UnityEngine;

public class SpriteVisibilityController : MonoBehaviour
{
    private ScoreTracker scoreTracker;

    [SerializeField]
    private Sprite[] roundImages;

    [SerializeField]
    private GameObject roundImage;

    void Start()
    {
        // Start the coroutine when the scene loads
        scoreTracker = FindFirstObjectByType<ScoreTracker>();
        roundImage.GetComponent<SpriteRenderer>().sprite = roundImages[scoreTracker.getRoundNumber()];
        StartCoroutine(HideSpriteAfterDelay());
    }

    private IEnumerator HideSpriteAfterDelay()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(3);

        // Disable the sprite renderer to make the sprite disappear
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
