using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private Sprite sound_on;
    [SerializeField] private Sprite sound_off;
    [SerializeField] private Component background;
    [SerializeField] private Component checkmark;

    private MusicScript musicScript;

    private const string AUDIO_MANAGER = "AudioManager";
    private const string TOGGLE_STATE_IN_INTEGER = "ToggleStateInInteger";

    private void Awake()
    {
        musicScript = GameObject.FindGameObjectWithTag(AUDIO_MANAGER).GetComponent<MusicScript>();

        if (PlayerPrefs.HasKey(TOGGLE_STATE_IN_INTEGER))
        {
            SetToggleState(ConvertIntegerToBool(PlayerPrefs.GetInt(TOGGLE_STATE_IN_INTEGER)));
        }
        else
        {
            SetToggleState(true);
        }
    }

    public void OnToggle()
    {
        SetToggleState(toggle.isOn);
        SaveToggleState();
    }

    public void PlayClickSound()
    {
        musicScript.Onclick();
    }

    private void SetToggleState(bool isOn)
    {
        if(isOn)
        {
            background.GetComponent<Image>().sprite = sound_on;
            checkmark.GetComponent<Image>().sprite = sound_on;

            musicScript.UnMute();
        }
        else
        {
            background.GetComponent<Image>().sprite = sound_off;
            checkmark.GetComponent<Image>().sprite = sound_off;

            musicScript.Mute();
        }
    }

    private int ConvertBoolToInteger(bool value)
    {
        return value ? 1 : 0;
    }

    private bool ConvertIntegerToBool(int value)
    {
        return value == 1 ? true : false;
    }

    private void SaveToggleState()
    {
        PlayerPrefs.SetInt(TOGGLE_STATE_IN_INTEGER, ConvertBoolToInteger(toggle.isOn));
        PlayerPrefs.Save();
    }
}
