using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePlayerNamesScript : MonoBehaviour
{
    [SerializeField] private GameObject playerNamesCanvas;
    [SerializeField] private InputField player1;
    [SerializeField] private InputField player2;

    private string player1Name;
    private string player2Name;

    private const string PLAYER_1 = "Player 1";
    private const string PLAYER_2 = "Player 2";

    private void Awake()
    {
        if (PlayerPrefs.HasKey(PLAYER_1))
        {
            player1Name = PlayerPrefs.GetString(PLAYER_1);
            player1.text = player1Name == PLAYER_1 ? "" : player1Name;
        }

        if (PlayerPrefs.HasKey(PLAYER_2))
        {
            player2Name = PlayerPrefs.GetString(PLAYER_2);
            player2.text = player2Name == PLAYER_2 ? "" : player2Name;
        }

        SavePlayerNames();
    }

    public void OnPlayButtonClicked()
    {        
        if (player1.text != player1Name && player1.text != "")
        {
            player1Name = player1.text;
        }
        else if (player1.text == "")
        {
            player1Name = PLAYER_1;
        }

        if (player2.text != player2Name && player2.text != "")
        {
            player2Name = player2.text;
        }
        else if (player2.text == "")
        {
            player2Name = PLAYER_2;
        }

        SavePlayerNames();

        Debug.Log(player1Name + " " + player2Name);

        playerNamesCanvas.SetActive(false);
    }

    public void OnResetButtonClicked()
    {
        player1.text = "";
        player1Name = PLAYER_1;
        player2.text = "";
        player2Name = PLAYER_2;
        SavePlayerNames();
    }

    public string GetPlayer1Name()
    {
        return player1Name;
    }
    
    public string GetPlayer2Name()
    {
        return player2Name;
    }

    private void SavePlayerNames()
    {
        PlayerPrefs.SetString(PLAYER_1, player1Name);
        PlayerPrefs.SetString(PLAYER_2, player2Name);
        PlayerPrefs.Save();
    }
}
