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
    public AudioSource criticalAudio;
    [SerializeField]
    private PlayerHealthSystem player;
    void Start()
    {
        player = GetComponent<PlayerHealthSystem>();
    }
    //Function: SFX
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(player.hp < 20f)
        {
            criticalAudio.PlayOneShot(criticalAudio.clip);
        }
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
    }

}
