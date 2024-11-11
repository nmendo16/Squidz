using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyGunPickup : MonoBehaviour
{
    public GunPickup pickupType;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            pickupType.pickup(collision.gameObject);
        }
    }
}
