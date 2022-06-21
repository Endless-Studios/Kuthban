using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    public GameObject pauseMenu;
    //public StopWatch stopWatch;
    public void ReplayGame()
    {
        // SceneManager.LoadScene("Oil_Rush");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        //stopWatch.paused = true;
        Time.timeScale = 0f;
        //GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        //GameState newGameState = currentGameState == GameState.Gameplay
        //    ? GameState.Paused
        //    : GameState.Gameplay;

        //GameStateManager.Instance.SetState(newGameState);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}

