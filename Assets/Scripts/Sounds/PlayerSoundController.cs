using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    public AudioSource playerAudio;
    public AudioClip wallbumpSound;
    public AudioClip hitSound;
    //Function#1: Wall bump effect
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            playerAudio.PlayOneShot(wallbumpSound);
        }
    }

}
