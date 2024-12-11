using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    public AudioSource wallhitAudio;
    public AudioSource normalbulletAudio;
    public AudioSource flameAudio;
    public AudioSource rocketAudio;
    public AudioSource cannonAudio;
    void Start()
    {
        
    }
    //Function#1: Wall bump effect
    public void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
                wallhitAudio.PlayOneShot(wallhitAudio.clip);
                break;
            case "NormalBullet":
                wallhitAudio.PlayOneShot(normalbulletAudio.clip);
                break;
            case "Flame":
                wallhitAudio.PlayOneShot(flameAudio.clip);
                break;
            case "Rocket":
                wallhitAudio.PlayOneShot(rocketAudio.clip);
                break;
            case "Cannon":
                wallhitAudio.PlayOneShot(cannonAudio.clip);
                break;
        }
        //if (collision.gameObject.CompareTag("Wall"))
        //{
        //    wallhitAudio.PlayOneShot(wallhitAudio.clip);
        //}
        //if (collision.gameObject.CompareTag("Bullet"))
        //{
        //    wallhitAudio.PlayOneShot(normalbulletAudio.clip);
        //}
    }

}
