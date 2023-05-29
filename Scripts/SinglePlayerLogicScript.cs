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
    private TTTAI ai = new TTTAI();
    char[] play = new char[9];
    private Button button;
    private int moveNumber = 0;
    private int difficulty = 4;
    private int previousMove = 69;
    private int choice =  (new System.Random().Next(2) + 1);
    private char nextCharacter = 'O';
    private bool gameIsOver = false;

    private const string DIFFICULTY_SELECTED_STRING = "DifficultySelectedString";
    private const string DIFFICULTY_SELECTED_INTEGER = "DifficultySelectedInteger";

    private void Start()
    {
        fill();
        message.text = (choice == 1) ? "Computer's First Move" : "Your First Move";
        if (choice == 1)
        {
            nextCharacter = 'X';
            outputbyComputer();//To start the game when computer is supposed to give the first move
        }
        if (PlayerPrefs.HasKey(DIFFICULTY_SELECTED_STRING) && PlayerPrefs.HasKey(DIFFICULTY_SELECTED_INTEGER))
        {
            selectedDifficultyString = PlayerPrefs.GetString(DIFFICULTY_SELECTED_STRING);
            difficulty = PlayerPrefs.GetInt(DIFFICULTY_SELECTED_INTEGER);
            Debug.Log(difficulty);
            selectedDifficulty.text = difficulty + ". " + selectedDifficultyString;
        }
        else
        {
            selectedDifficulty.text = "No Difficulty Selected";
            Debug.LogError("User did not select a difficulty level");
        }
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
        if (gameIsOver)
        { return; }
        message.text = null;
        int n = GetLastButtonClicked();
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
        button.enabled = false;
        previousMove = n;
        moveNumber++;
        check();
        if (!gameIsOver)
        {
            outputbyComputer();
        }
    }
    private void outputbyComputer()
    {
        // Calling TTTAI
        int n = ai.input(play, choice, previousMove, difficulty);
        //message.text = "Move By Player";
        play[n] = nextCharacter;
        button = GameObject.FindGameObjectWithTag(n.ToString()).GetComponent<Button>();
        button.enabled = false;
        button.image.sprite = (nextCharacter == 'X') ? X : O;
        moveNumber++;
            check();
    }
    void check()
    {
        Check check1 = new Check();
        int store = check1.check(play);
        
        if (store + choice == 2)
        {
            message.text = "Congratulations! You Won";
            moveNumber = 69;            
        }
        else if (store == 0 || store == 1)
        {
            message.text = "Computer Won";
            moveNumber = 69;
        }
        else if (moveNumber >= 9)
        {
            message.text = "Game is a Draw";
            moveNumber = 69;
        }
        if (moveNumber == 69)
        {
            gameIsOver = true;
            onGameOver();
        }
    }
    private void onGameOver()
    {
        for (int j = 0; j < 9; j++)
        {
            button = GameObject.FindGameObjectWithTag(j.ToString()).GetComponent<Button>();
            if (button.image.sprite == defaultSprite)
            {
                button.interactable = false;                
            }
        }
        gameOver();
    }
    private void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}