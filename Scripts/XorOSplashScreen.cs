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

    private Sprite playerChoiceSprite;
    private char playerChoiceChar;
   public void OnXButtonClicked()
    {
        playerChoiceSprite = X_Sprite;
        playerChoiceChar = X;
        playAsText.text = PLAY_AS + playerChoiceChar;
        XorOChoiceButton.image.sprite = playerChoiceSprite;
        chooseXorOCanvas.SetActive(false);
        logicManager.SetActive(true);
    }

   public void OnOButtonClicked()
    {
        playerChoiceSprite = O_Sprite;
        playerChoiceChar = O;
        playAsText.text = PLAY_AS + playerChoiceChar;
        XorOChoiceButton.image.sprite = playerChoiceSprite;
        chooseXorOCanvas.SetActive(false);
        logicManager.SetActive(true);
    }

    public void OnXorOChoiceButtonClicked()
    {
        chooseXorOCanvas.SetActive(true);
    }

    public Sprite GetPlayerChoiceSprite()
    {
        return playerChoiceSprite;
    }

    public char GetPlayerChoiceChar()
    {
        return playerChoiceChar;
    }
}
