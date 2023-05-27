using UnityEngine;
using UnityEngine.UI;

public class SelectDifficultyScript : MonoBehaviour
{
    [SerializeField] private Text difficultyText;
    [SerializeField] private Slider difficultySlider;
    [SerializeField] private Color orange;

    private string selectedDifficulty;

    private const string DIFFICULTY_SELECTED = "DifficultySelected";
    
    public void SetDifficultyText()
    {
        float value = difficultySlider.value;
        if (value == 0)
        {
            difficultyText.color = Color.green;
            difficultyText.text = "Easy";
        }
        else if (value == 1)
        {
            difficultyText.color = Color.yellow;
            difficultyText.text = "Medium";
        }
        else if (value == 2)
        {
            difficultyText.color = orange;
            difficultyText.text = "Hard";
        }
        else if (value == 3)
        {
            difficultyText.color = Color.red;
            difficultyText.text = "Impossible";
        }
        selectedDifficulty = difficultyText.text;
        SaveDifficultyText();
    }

    private void SaveDifficultyText()
    {
        PlayerPrefs.SetString(DIFFICULTY_SELECTED, selectedDifficulty);
    }
}