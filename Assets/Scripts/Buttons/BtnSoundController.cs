using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSoundController : MonoBehaviour
{
    public AudioSource button;
    public AudioClip hoverSound;
    public AudioClip clickedSound;

    //Function #1: Hover effect
    public void HoverSFX()
    {
        button.PlayOneShot(hoverSound);
    }
    public void ClickedSFX()
    {
        button.PlayOneShot(clickedSound);
    }
}
