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

        Transform gunHolder = player.transform.Find("GunHolder");
        Destroy(player.transform.Find("GunHolder").gameObject.transform.GetChild(0).gameObject);
        GameObject newGun = Instantiate(gunType, gunHolder);
    }
}
