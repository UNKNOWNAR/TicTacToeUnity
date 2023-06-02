using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XorOSplashScreen : MonoBehaviour
{
    [SerializeField] private GameObject chooseXorOCanvas;
    [SerializeField] private GameObject logicManager;
    [SerializeField] private Sprite X_Sprite;
    [SerializeField] private Sprite O_Sprite;
    [SerializeField] private Button XorOChoiceButton;
    [SerializeField] private Text playAsText;

    private const char X = 'X';
    private const char O = 'O';
    private const string PLAY_AS = "Play As:   ";
    private const string SCENE_OPENED_FOR_FIRST_TIME = "SceneOpenedForFirstTime";
    private const string PLAYER_CHOICE_CHAR = "PlayerChoiceChar";

    private Sprite playerChoiceSprite;
    private char playerChoiceChar;

    private void Start()
    {
        if (!PlayerPrefs.HasKey(SCENE_OPENED_FOR_FIRST_TIME) || PlayerPrefs.GetInt(SCENE_OPENED_FOR_FIRST_TIME) == 1) {
            PlayerPrefs.SetInt(SCENE_OPENED_FOR_FIRST_TIME, 0);
            chooseXorOCanvas.SetActive(true);
        }
        else
        {
            chooseXorOCanvas.SetActive(false);
            playerChoiceChar = char.Parse(PlayerPrefs.GetString(PLAYER_CHOICE_CHAR));
            playerChoiceSprite = GetSpriteFromChar(playerChoiceChar);
            XorOChoiceButton.image.sprite = playerChoiceSprite;
            logicManager.SetActive(true);
            Debug.Log("player choice char in splash screen = "+playerChoiceChar);
        }
    }
    public void OnXButtonClicked()
    {
        playerChoiceSprite = X_Sprite;
        playerChoiceChar = X;
        playAsText.text = PLAY_AS + playerChoiceChar;
        XorOChoiceButton.image.sprite = playerChoiceSprite;
        chooseXorOCanvas.SetActive(false);
        logicManager.SetActive(true);
        SavePlayerChoiceChar();
        Debug.Log("player choice char in splash screen = " + playerChoiceChar);
    }

   public void OnOButtonClicked()
    {
        playerChoiceSprite = O_Sprite;
        playerChoiceChar = O;
        playAsText.text = PLAY_AS + playerChoiceChar;
        XorOChoiceButton.image.sprite = playerChoiceSprite;
        chooseXorOCanvas.SetActive(false);
        logicManager.SetActive(true);
        SavePlayerChoiceChar();
        Debug.Log("player choice char in splash screen = " + playerChoiceChar);
    }

    public void OnXorOChoiceButtonClicked()
    {
        PlayerPrefs.SetInt(SCENE_OPENED_FOR_FIRST_TIME, 1);
    }

    public Sprite GetPlayerChoiceSprite()
    {
        return playerChoiceSprite;
    }

    public char GetPlayerChoiceChar()
    {
        return playerChoiceChar;
    }

    private void SavePlayerChoiceChar()
    {
        PlayerPrefs.SetString(PLAYER_CHOICE_CHAR, playerChoiceChar.ToString());
        PlayerPrefs.Save();
    }

    private Sprite GetSpriteFromChar(char c)
    {
        if (c == X)
            return X_Sprite;
        else if (c == O)
            return O_Sprite;
        else
        {
            Debug.LogError("No sprite set");
            return null;
        }
    }
}
