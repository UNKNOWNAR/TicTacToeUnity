using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource clickSource;

    private static MusicScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        musicSource.volume = 0.5f;
        clickSource.volume = 0.25f;

        musicSource.loop = true;
    }

    public void Onclick()
    {
        clickSource.Play();
    }

    public void Mute()
    {
        musicSource.volume = 0;
        clickSource.volume = 0;
    }

    public void UnMute()
    {
        musicSource.volume = 0.5f;
        clickSource.volume = 0.25f;
    }
}
