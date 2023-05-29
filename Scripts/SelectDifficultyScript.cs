using UnityEngine;
using UnityEngine.UI;

public class SelectDifficultyScript : MonoBehaviour
{
    [SerializeField] private Text difficultyText;
    [SerializeField] private Slider difficultySlider;
    [SerializeField] private Color orange;

    private string selectedDifficulty;
    private int selectedDifficultyIntegerValue;

    private const string DIFFICULTY_SELECTED_STRING = "DifficultySelectedString";
    private const string DIFFICULTY_SELECTED_INTEGER = "DifficultySelectedInteger";

    private void Awake()
    {
        selectedDifficulty = "Easy";
        selectedDifficultyIntegerValue = 1;
        SaveDifficultyTextAndValue();
    }

    public void SetDifficultyText()
    {
        float difficultySliderValue = difficultySlider.value;

        if (difficultySliderValue == 0)
        {
            difficultyText.color = Color.green;
            difficultyText.text = "Easy";
        }
        else if (difficultySliderValue == 1)
        {
            difficultyText.color = Color.yellow;
            difficultyText.text = "Medium";
        }
        else if (difficultySliderValue == 2)
        {
            difficultyText.color = orange;
            difficultyText.text = "Hard";
        }
        else if (difficultySliderValue == 3)
        {
            difficultyText.color = Color.red;
            difficultyText.text = "Impossible";
        }
        selectedDifficulty = difficultyText.text;
        selectedDifficultyIntegerValue = (int) difficultySliderValue + 1;
        SaveDifficultyTextAndValue();
    }

    private void SaveDifficultyTextAndValue()
    {
        PlayerPrefs.SetString(DIFFICULTY_SELECTED_STRING, selectedDifficulty);
        PlayerPrefs.SetInt(DIFFICULTY_SELECTED_INTEGER, selectedDifficultyIntegerValue);
        PlayerPrefs.Save();
    }
}