
using System.Collections;
using UnityEngine;

public class SpriteVisibilityController : MonoBehaviour
{
    void Start()
    {
        // Start the coroutine when the scene loads
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
