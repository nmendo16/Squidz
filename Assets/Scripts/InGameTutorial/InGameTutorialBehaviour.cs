using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameTutorialBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject RotateKeys;
    [SerializeField]
    private GameObject ShootKey;
    [SerializeField]
    private GameObject SwitchKey;
    private ScoreTracker scoreTracker;
    // Start is called before the first frame update
    void Start()
    {
        scoreTracker = FindFirstObjectByType<ScoreTracker>();
        Debug.Log(scoreTracker.getRoundNumber());
        if (scoreTracker.getRoundNumber() == 0)
        {
            StartCoroutine(DisplayTutorial());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DisplayTutorial()
    {
        Debug.Log("DisplayTutorial");
        RotateKeys.SetActive(true);
        yield return new WaitForSeconds(3);
        RotateKeys.SetActive(false);
        ShootKey.SetActive(true);
        yield return new WaitForSeconds(3);
        ShootKey.SetActive(false);
        SwitchKey.SetActive(true);
        yield return new WaitForSeconds(3);
        SwitchKey.SetActive(false);
        Destroy(gameObject);
    }
}
