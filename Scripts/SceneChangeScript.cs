using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    private const string HOME_SCENE = "0. HomeScene";
    private const string SELECT_GAME_MODE_SCENE = "1. SelectGameModeScene";
    private const string SELECT_DIFFICULTY_SCENE = "2. SelectDifficultyScene";
    private const string MULTI_PLAYER_SCENE = "2. MultiplayerScene";
    private const string SINGLE_PLAYER_SCENE = "3. SinglePlayerScene";

    public void OpenSelectGameModeScene()
    {
        SceneManager.LoadScene(SELECT_GAME_MODE_SCENE);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    public void OpenMultiPlayer()
    {
        SceneManager.LoadScene(MULTI_PLAYER_SCENE);
    }

    public void OpenSelectDifficultyScene()
    {
        SceneManager.LoadScene(SELECT_DIFFICULTY_SCENE);
    }

    public void OpenSinglePlayerScene()
    {
        SceneManager.LoadScene(SINGLE_PLAYER_SCENE);
    }

    public void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenHomeScene()
    {
        SceneManager.LoadScene(HOME_SCENE);
    }
}
