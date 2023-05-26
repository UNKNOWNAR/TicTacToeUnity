using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    public Toggle toggle;
    public Sprite sound_on;
    public Sprite sound_off;
    public Component background;
    public Component checkmark;
    public AudioSource click;
    public void onToggle()
    {
        if(toggle.isOn)
        {
            background.GetComponent<Image>().sprite = sound_on;
            checkmark.GetComponent<Image>().sprite = sound_on;
            click.mute = false;
        }
        else if(!toggle.isOn)
        {
            background.GetComponent<Image>().sprite = sound_off;
            checkmark.GetComponent<Image>().sprite = sound_off;
            click.mute = true;
        }
    }
}