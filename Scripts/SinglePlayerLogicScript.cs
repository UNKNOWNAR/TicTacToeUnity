using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayerLogicScript : MonoBehaviour
{
    [SerializeField] private Text selectedDifficulty;

    private const string DIFFICULTY_SELECTED = "DifficultySelected";

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
}
