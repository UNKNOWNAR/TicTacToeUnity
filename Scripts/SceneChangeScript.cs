using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    private const string HOME_SCENE = "HomeScene";
    private const string SELECT_GAME_MODE_SCENE = "SelectGameModeScene";
    private const string SELECT_DIFFICULTY_SCENE = "SelectDifficultyScene";
    private const string MULTI_PLAYER_SCENE = "MultiplayerScene";
    private const string SINGLE_PLAYER_SCENE = "SinglePlayerScene";

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
