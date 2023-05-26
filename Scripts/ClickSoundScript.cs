using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSoundScript : MonoBehaviour
{
    public AudioSource clickSource;
    public void play()
    {
        clickSource.Play();
    }
}
