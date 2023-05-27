using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SinglePlayerLogicScript : MonoBehaviour
{
    [SerializeField] private Text selectedDifficulty;
    [SerializeField] private Sprite X;
    [SerializeField] private Sprite O;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Text message;
    [SerializeField] private GameObject gameOverScreen;

    private string selectedDifficultyString;
    private int selectedDifficultyInteger;

    private const string DIFFICULTY_SELECTED_STRING = "DifficultySelectedString";
    private const string DIFFICULTY_SELECTED_INTEGER = "DifficultySelectedInteger";

    [SerializeField] private TTTAI ai;
    [SerializeField] private Check check1;
    char[] play = new char[9];
    private Button button;
    private int moveNumber = 0;
    private int difficulty = 4;
    private int previousMove = 69;

    // setting choice to 0 manually for testing
    private int choice = 0; //(new System.Random().Next(2) + 1);
    private char nextCharacter = 'O';

    private int n;
    private void Start()
    {
        message.text = (choice == 1) ? "Computer's First Move" : "Players First Move";
        if (choice == 1)
        {
            nextCharacter = 'X';
            outputbyComputer(); // To start the game when computer is supposed to give the first move
        }
        if (PlayerPrefs.HasKey(DIFFICULTY_SELECTED_STRING) && PlayerPrefs.HasKey(DIFFICULTY_SELECTED_INTEGER))
        {
            selectedDifficultyString = PlayerPrefs.GetString(DIFFICULTY_SELECTED_STRING);
            selectedDifficultyInteger = PlayerPrefs.GetInt(DIFFICULTY_SELECTED_INTEGER);
            
            selectedDifficulty.text = selectedDifficultyInteger + ". " + selectedDifficultyString;
        }
        else
        {
            selectedDifficulty.text = "No Difficulty Selected";
            Debug.LogError("User did not select a difficulty level");
        }
        fill();

        /*for (int i = 0; i < play.Length; i++)
        {
            Debug.Log(i+". " + play[i]);
        }*/
    }

    private void Update()
    {
        //n = GetLastButtonClicked();
        //button = GameObject.FindGameObjectWithTag(n.ToString()).GetComponent<Button>();
    }

    int GetLastButtonClicked()
    {
        return int.Parse(EventSystem.current.currentSelectedGameObject.name);
    }
    private void fill()
    {
        // Fill the array with blank spaces
        for (int i = 0; i < 9; i++)
            play[i] = ' ';
    }
    public void OnButtonClicked()
    {
        int n = GetLastButtonClicked();
        Debug.Log(n);
        button = GameObject.FindGameObjectWithTag(n.ToString()).GetComponent<Button>();
        if (moveNumber % 2 == 0)
        {
            play[n] = 'X';
            button.image.sprite = X;
        }
        else
        {
            play[n] = 'O';
            button.image.sprite = O;
        }

        /*for (int i = 0; i < play.Length; i++)
        {
            Debug.Log(i + ". " + play[i]);
        }*/

        button.enabled = false;
        previousMove = n;
        moveNumber++;

        //Debug.Log(moveNumber);
        //if (moveNumber > 4)

            check();
        outputbyComputer();

        //Debug.Log(moveNumber);
    }
    private void outputbyComputer()
    {
        // Calling TTTAI

        //message.text = "MOVE BY COMPUTER,PLAYER ENTER";

        int n = ai.input(play, choice, previousMove, difficulty);
        Debug.Log(n);
        play[n] = nextCharacter;

        /*for (int i = 0; i < play.Length; i++)
        {
            Debug.Log(i + ". " + play[i]);
        }*/

        button = GameObject.FindGameObjectWithTag(n.ToString()).GetComponent<Button>();
        button.image.sprite = (nextCharacter == 'X') ? X : O;
        button.enabled = false;
        moveNumber++;
    }
    void check()
    {
        if(moveNumber==9)
        {
            message.text = "GameDrawn";
            moveNumber = 69;

            //Debug.Log("Error 1");
        }

        // The following part is causing match to end after 1 move by user and one move by ai

        /*else if (check1.check(play)+choice==2)
        {
            message.text = "Congratulations, Player Won";
            moveNumber = 69;

            //Debug.Log("Error 2");
        }
        else
        {
            message.text = "Computer Won";
            moveNumber = 69;
        }*/

        if (moveNumber == 69)
        {
            onGameOver();

            //Debug.Log("Game Over");
        }
    }
    private void onGameOver()
    {
        for (int j = 0; j < 9; j++)
        {
            button = GameObject.FindGameObjectWithTag(j.ToString()).GetComponent<Button>();
            if (button.image.sprite == defaultSprite)
                button.interactable = false;

            // No need to fill array after match end since it is resetting automatically when user presses restart or returns to homescene
            //fill();
        }
        gameOver();
    }
    private void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}