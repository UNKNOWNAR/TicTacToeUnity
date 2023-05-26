using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MultiPlayerLogicScript : MonoBehaviour
{
    [SerializeField] private Sprite X;
    [SerializeField] private Sprite O;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Text result;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioSource clickSoundSource;

    private int currentButtonNumber,numberOfMoves;
    private Button button;
    private bool isTurnOfX;
    private char[] moveArray;
    private float pitch;

    private void Awake()
    {
        numberOfMoves = 0;
        isTurnOfX = true;
        moveArray = new char[9];
        pitch = 0.1f;
    }

    private void Update()
    {
        currentButtonNumber = GetLastButtonClicked();
        button = GameObject.FindGameObjectWithTag(currentButtonNumber.ToString()).GetComponent<Button>();
        if (result.text == "X Wins!" || result.text == "O Wins!" || result.text == "Draw!")
        {
            onGameOver();
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
        clickSoundSource.pitch = pitch;
        clickSoundSource.Play();
        pitch += 0.05F;
    }

    public void checkWinner()
    {
        //checks rows

        if (moveArray[0] == moveArray[1] && moveArray[1] == moveArray[2])
        {
            result.text = moveArray[0].ToString() + " Wins!";
        }
        else if (moveArray[3] == moveArray[4] && moveArray[4] == moveArray[5])
        {
            result.text = moveArray[3].ToString() + " Wins!";
        }
        else if (moveArray[6] == moveArray[7] && moveArray[7] == moveArray[8])
        {
            result.text = moveArray[6].ToString() + " Wins!";
        }

        //checks columns

        else if (moveArray[0] == moveArray[3] && moveArray[3] == moveArray[6])
        {
            result.text = moveArray[0].ToString() + " Wins!";
        }
        else if (moveArray[1] == moveArray[4] && moveArray[4] == moveArray[7])
        {
            result.text = moveArray[1].ToString() + " Wins!";
        }
        else if (moveArray[2] == moveArray[5] && moveArray[5] == moveArray[8])
        {
            result.text = moveArray[2].ToString() + " Wins!";
        }

        //checks diagonals

        else if (moveArray[0] == moveArray[4] && moveArray[4] == moveArray[8])
        {
            result.text = moveArray[0].ToString() + " Wins!";
        }
        else if (moveArray[2] == moveArray[4] && moveArray[4] == moveArray[6])
        {
            result.text = moveArray[2].ToString() + " Wins!";
        }
        else if(numberOfMoves==9)
        {
            result.text = "Draw!";
        }
    }

    private void onGameOver()
    {
        for (int j = 0; j < 9; j++)
        {
            button = GameObject.FindGameObjectWithTag(j.ToString()).GetComponent<Button>();
            if (button.image.sprite == defaultSprite)
                button.interactable = false;
        }
        gameOver();
    }

    private void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}