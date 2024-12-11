using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitSound : MonoBehaviour
{
    public AudioSource hitSound;

    void Start()
    {
        hitSound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            hitSound.PlayOneShot(hitSound.clip);
        }
    }
}
