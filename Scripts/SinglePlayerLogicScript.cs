using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SinglePlayerLogicScript : MonoBehaviour
{
    [SerializeField] private Text selectedDifficulty;
    [SerializeField] private Sprite X;
    [SerializeField] private Sprite O;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Text result;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioSource clickSoundSource;

    private const string DIFFICULTY_SELECTED = "DifficultySelected";
    TTTAI ai = new TTTAI();
    Check check1 = new Check();
    char[] play = new char[9];
    private void Start()
    {
        if (PlayerPrefs.HasKey(DIFFICULTY_SELECTED))
        {
            selectedDifficulty.text = PlayerPrefs.GetString(DIFFICULTY_SELECTED);
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
    private int input(char c)
    {
        int n = GetLastButtonClicked();
        if (play[n] == ' ')
        {
            play[n] = c;
            return (n);
        }
        return 10;
    }
}