using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MultiPlayerLogicScript : MonoBehaviour
{
    [SerializeField] private Sprite X;
    [SerializeField] private Sprite O;
    [SerializeField] private Sprite XWIN;
    [SerializeField] private Sprite OWIN;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Text result;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private SavePlayerNamesScript playerNames;

    private int currentButtonNumber, numberOfMoves;
    private Button button;
    private bool isTurnOfX;
    private char[] moveArray;
    private int winrange = 0;
    private char CharWin = ' ';
    private char nextCharacter = ' ';

    private void Awake()
    {
        numberOfMoves = 0;
        isTurnOfX = true;
        moveArray = new char[9];
    }

    private void Update()
    {
        currentButtonNumber = GetLastButtonClicked();
        button = GameObject.FindGameObjectWithTag(currentButtonNumber.ToString()).GetComponent<Button>();
        if (result.text == "X Wins!" || result.text == "O Wins!" || result.text == "Draw!")
        {
            OnGameOver();
        }
    }

    private int GetLastButtonClicked()
    {
        return int.Parse(EventSystem.current.currentSelectedGameObject.name);
    }

    public void OnButtonClicked()
    {
        if (isTurnOfX)
        {
            button.image.sprite = X;
            moveArray[currentButtonNumber] = 'X';
            isTurnOfX = false;
        }
        else
        {
            button.image.sprite = O;
            moveArray[currentButtonNumber] = 'O';
            isTurnOfX = true;
        }
        button.enabled = false;
        numberOfMoves++;
        CheckForGameOver();
    }

    void CheckForGameOver()
    {
        string playerWithX = playerNames.GetPlayer1Name();
        string playerWithO = playerNames.GetPlayer2Name();
        Check check1 = new Check();
        int store = check1.check(moveArray);
        winrange = store / 10;
        store = (store != 69) ? store % 10 : store;
        if (store == 0)
            CharWin = 'X';
        else
            CharWin = 'Y';
        if (store == 0)
        {
            result.text = playerWithX + " Wins!";
            numberOfMoves = 69;
        }
        else if (store == 1)
        {
            result.text = playerWithO + " Wins!";
            numberOfMoves = 69;
        }
        else if (numberOfMoves >= 9)
        {
            result.text = "Game is a Draw";
            numberOfMoves = 69;
        }
        if (numberOfMoves == 69)
        {
            if (store == 0)
                nextCharacter = 'X';
            else if (store == 1)
                nextCharacter = 'O';
            OnGameOver();
        }
    }

    private void OnGameOver()
    {
        int i = winrange / 10;
        int d = winrange % 10;
        int loopmove = 0;
        for (int j = 0; j < 9; j++)
        {
            button = GameObject.FindGameObjectWithTag(j.ToString()).GetComponent<Button>();
            if (button.image.sprite == defaultSprite)
                button.interactable = false;
            else if(j==i&&loopmove!=3&&winrange!=6)
            {
                if (nextCharacter == 'X')
                    button.image.sprite = XWIN;
                else if (nextCharacter == 'O')
                    button.image.sprite = OWIN;
                i += d;
                loopmove++;
            }
        }
        EnableGameOverScreen();
    }

    private void EnableGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }
}