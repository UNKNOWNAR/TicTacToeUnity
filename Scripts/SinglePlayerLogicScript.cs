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
    [SerializeField] private AudioSource clickSoundSource;

    private string selectedDifficultyString;

    private const string DIFFICULTY_SELECTED = "DifficultySelected";
    TTTAI ai = new TTTAI();
    Check check1 = new Check();
    char[] play = new char[9];
    private Button button;
    private int moveNumber = 0;
    private int difficulty = 4;
    private int previousMove = 69;
    private int choice = (new System.Random().Next(2) + 1);
    private char nextCharacter = 'O';
    private void Start()
    {
        message.text = (choice == 1) ? "Computer's First Move" : "Players First Move";
        if (choice == 1)
        {
            nextCharacter = 'X';
            outputbyComputer();//To start the game when computer is supposed to give the first move
        }
        if (PlayerPrefs.HasKey(DIFFICULTY_SELECTED))
        {
            selectedDifficulty.text = PlayerPrefs.GetString(DIFFICULTY_SELECTED);
            selectedDifficultyString = PlayerPrefs.GetString(DIFFICULTY_SELECTED);
        }
        else
        {
            selectedDifficulty.text = "No Difficulty Selected";
            Debug.LogError("User did not select a difficulty level");
        }
        fill();
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
        if (moveNumber > 4)
            check();
        outputbyComputer();
    }
    private void outputbyComputer()
    {
        // Calling TTTAI
        message.text = "MOVE BY COMPUTER,PLAYER ENTER";
        int n = ai.input(play, choice, previousMove, difficulty);
        button.enabled = false;
        play[n] = nextCharacter;
        button = GameObject.FindGameObjectWithTag(n.ToString()).GetComponent<Button>();
        button.image.sprite = (nextCharacter=='X')?X: O;
        moveNumber++;
    }
    void check()
    {
        if(moveNumber==9)
        {
            message.text = "GameDrawn";
            moveNumber = 69;
        }
        else if (check1.check(play)+choice==2)
        {
            message.text = "Congratulations, Player Won";
            moveNumber = 69;
        }
        else
        {
            message.text = "Computer Won";
            moveNumber = 69;
        }
        if (moveNumber == 69)
            onGameOver();
    }
    private void onGameOver()
    {
        for (int j = 0; j < 9; j++)
        {
            button = GameObject.FindGameObjectWithTag(j.ToString()).GetComponent<Button>();
            if (button.image.sprite == defaultSprite)
                button.interactable = false;
            fill();
        }
        gameOver();
    }
    private void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}