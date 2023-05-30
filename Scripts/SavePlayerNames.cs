using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePlayerNames : MonoBehaviour
{
    [SerializeField] private GameObject playerNamesCanvas;
    [SerializeField] private InputField player1;
    [SerializeField] private InputField player2;

    private string player1Name;
    private string player2Name;

    public void OnPlayButtonClicked()
    {
        player1Name = "Player 1";
        player2Name = "Player 2";

        if (player1.text != " ")
        {
            player1Name = player1.text;
        }

        if (player2.text != " ")
        {
            player2Name = player2.text;
        }   
        
        Debug.Log(player1Name + " " + player2Name);

        playerNamesCanvas.SetActive(false);
    }

    public string GetPlayer1Name()
    {
        return player1Name;
    }
    
    public string GetPlayer2Name()
    {
        return player2Name;
    }
}
