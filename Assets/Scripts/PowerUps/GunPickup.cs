using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


[CreateAssetMenu(menuName = "GunPickUps")]
public class GunPickup : ScriptableObject
{
    public GameObject gunType;
    public void pickup(GameObject player)
    {
        int currentGunSize = player.GetComponent<GunManager>().gunPrefabs.Length;

        foreach (GameObject go in player.GetComponent<GunManager>().gunPrefabs)// Check that the player does not already have this gun
        {
            if (go == gunType)
            {
                return;
            }
        }

        int newGunSize = currentGunSize + 1;
        GameObject[] newGuns = new GameObject[newGunSize];

        for (int i = 0; i < currentGunSize; i++)  //Creates a new array with all old guns + the new gun to add then replaces the players array of guns
        {
            newGuns[i] = player.GetComponent<GunManager>().gunPrefabs[i];
        }
        newGuns[newGunSize - 1] = gunType;
        player.GetComponent<GunManager>().gunPrefabs = newGuns;
        
        
    }
}
