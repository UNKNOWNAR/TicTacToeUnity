using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySplashScreen : MonoBehaviour
{
    [SerializeField] private Button difficultyButton;

    private const string DIFFICULTY_SELECTED_COLOR = "DifficultySelectedColor";

    private void Awake()
    {
        if (PlayerPrefs.HasKey(DIFFICULTY_SELECTED_COLOR))
        {
            Color difficultyButtonColor = Color.green;
            string selectedDifficultyColorString = PlayerPrefs.GetString(DIFFICULTY_SELECTED_COLOR);
            ColorUtility.TryParseHtmlString("#"+selectedDifficultyColorString, out difficultyButtonColor);
            difficultyButton.image.color = difficultyButtonColor;
        }
    }
}
