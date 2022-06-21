using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActionsRally : MonoBehaviour
{
    
    public GameObject pauseMenu;
   // public StopWatch stopWatch;
    public CountdownController countDownController;
    public GameObject timeManager;

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
        Time.timeScale = 0f;
        countDownController.GetComponent<StopWatch>().paused = true;
        countDownController.car.GetComponent<carController>().enabled = false;
        timeManager.GetComponent<time_manager>().enabled = false;


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
        timeManager.GetComponent<time_manager>().enabled = true;
        countDownController.GetComponent<StopWatch>().paused = false;
        countDownController.car.GetComponent<carController>().enabled = true;

    }
}

