
using System.Collections;
using UnityEngine;

public class SpriteVisibilityController : MonoBehaviour
{
    [SerializeField]
    private ScoreTracker scoreTracker;

    [SerializeField]
    private Sprite[] roundImages;

    [SerializeField]
    private GameObject roundImage;

    void Start()
    {
        // Start the coroutine when the scene loads
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
