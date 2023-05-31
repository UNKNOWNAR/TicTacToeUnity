using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SinglePlayerLogicScript : MonoBehaviour
{
    [SerializeField] private Text selectedDifficulty;
    [SerializeField] private Sprite X;
    [SerializeField] private Sprite O;
    [SerializeField] private Sprite XWIN;
    [SerializeField] private Sprite OWIN;
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
    private int choice = (new System.Random().Next(2) + 1);
    private char nextCharacter = 'O';//stores charcter for computers move and also the winning character
    private bool gameIsOver = false;
    private int winrange = 0;//contains a code example 13 start from 1 and increment with 3 times to get the win line

    private const string DIFFICULTY_SELECTED_STRING = "DifficultySelectedString";
    private const string DIFFICULTY_SELECTED_INTEGER = "DifficultySelectedInteger";

    private void Start()
    {
        fill();
        message.text = (choice == 1) ? "Computer's First Move" : "Your First Move";
        if (choice == 1)
        {
            nextCharacter = 'X';
            check1(); //To start the game when computer is supposed to give the first move
        }
        if (PlayerPrefs.HasKey(DIFFICULTY_SELECTED_STRING) && PlayerPrefs.HasKey(DIFFICULTY_SELECTED_INTEGER))
        {
            selectedDifficultyString = PlayerPrefs.GetString(DIFFICULTY_SELECTED_STRING);
            difficulty = PlayerPrefs.GetInt(DIFFICULTY_SELECTED_INTEGER);
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
            check1();
    }
    private void outputbyComputer(int n)
    {
        // Calling TTTAI
        n = (n==0)?ai.input(play, choice, previousMove, difficulty):n;
        //message.text = "Move By Player";
        play[n] = nextCharacter;
        button = GameObject.FindGameObjectWithTag(n.ToString()).GetComponent<Button>();
        button.enabled = false;
        button.image.sprite = (nextCharacter == 'X') ? X : O;
        moveNumber++;
            check();
    }
    private void RandomMove()
    {
        int n = 0;
        if (difficulty == 1)
            n = ai.Random(play);
        int randomNumber = ai.randomforClasses(1, 11);//generating random numbers from 1 to 10 from TTTAI class
        if (randomNumber % 2 == 0 && difficulty == 2)
            n = ai.Random(play);
        else if (randomNumber % 3 == 0 && difficulty == 3)
            n = ai.Random(play);
        outputbyComputer(n);
    }
    void check1()
    {
        if (difficulty == 4)
            outputbyComputer(0);
        else
            RandomMove();
    }
    void check()
    {
        Check check1 = new Check();
        int store = check1.check(play);
        winrange = store / 10;
        store = (store != 69) ? store % 10:store;
        
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
            if (store == 0)
                nextCharacter = 'X';
            else if (store == 1)
                nextCharacter = 'O';
            gameIsOver = true;
            onGameOver();
        }
    }
    private void onGameOver()
    {
        for (int j = 0; j < 9; j++)
        {
            int i = winrange / 10;
            int d = winrange % 10;
            int loopmove = 0;
            button = GameObject.FindGameObjectWithTag(j.ToString()).GetComponent<Button>();
            if (button.image.sprite == defaultSprite)
            {
                button.interactable = false;                
            }
            else if (j == i && loopmove != 3&&winrange!=6)
            {
                if (nextCharacter == 'X')
                    button.image.sprite = XWIN;
                else if(nextCharacter == 'O')
                    button.image.sprite = OWIN;
                i += d;
                loopmove++;
            }
        }
        gameOver();
    }
    private void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}