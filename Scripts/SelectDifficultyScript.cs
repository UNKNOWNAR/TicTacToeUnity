using UnityEngine;
using UnityEngine.UI;

public class SelectDifficultyScript : MonoBehaviour
{
    [SerializeField] private Text difficultyText;
    [SerializeField] private Slider difficultySlider;
    [SerializeField] private Color orange;

    private string selectedDifficultyString;
    private int selectedDifficultyInt;
    private float difficultySliderValue;
    private Color selectedDifficultyColor;

    private const string DIFFICULTY_SELECTED_STRING = "DifficultySelectedString";
    private const string DIFFICULTY_SELECTED_INTEGER = "DifficultySelectedInteger";
    private const string DIFFICULTY_SELECTED_COLOR = "DifficultySelectedColor";
    private const string DIFFICULTY_SLIDER_POSITION = "DifficultySliderPosition";

    private void Awake()
    {
        selectedDifficultyString = "Easy";
        selectedDifficultyInt = 1;
        selectedDifficultyColor = Color.green;
        difficultySlider.value = PlayerPrefs.HasKey(DIFFICULTY_SLIDER_POSITION) ? PlayerPrefs.GetFloat(DIFFICULTY_SLIDER_POSITION) : 0;
        SaveDifficultyTextString();
        SaveDifficultyIntValue();
        SaveDifficultyColorString();
        SaveDifficultySliderPositionFloatValue();
    }

    public void SetDifficultyText()
    {
        difficultySliderValue = difficultySlider.value;

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
        selectedDifficultyString = difficultyText.text;
        selectedDifficultyInt = (int) difficultySliderValue + 1;
        selectedDifficultyColor = difficultyText.color;
        SaveDifficultyTextString();
        SaveDifficultyIntValue();
        SaveDifficultyColorString();
        SaveDifficultySliderPositionFloatValue();
    }

    private void SaveDifficultyTextString()
    {
        PlayerPrefs.SetString(DIFFICULTY_SELECTED_STRING, selectedDifficultyString);
        PlayerPrefs.Save();
    }

    private void SaveDifficultyIntValue()
    {
        PlayerPrefs.SetInt(DIFFICULTY_SELECTED_INTEGER, selectedDifficultyInt);
        PlayerPrefs.Save();
    }

    private void SaveDifficultyColorString()
    {
        PlayerPrefs.SetString(DIFFICULTY_SELECTED_COLOR, ColorUtility.ToHtmlStringRGB(selectedDifficultyColor));
        PlayerPrefs.Save();
    }

    private void SaveDifficultySliderPositionFloatValue()
    {
        PlayerPrefs.SetFloat(DIFFICULTY_SLIDER_POSITION, difficultySliderValue);
        PlayerPrefs.Save();
    }
}