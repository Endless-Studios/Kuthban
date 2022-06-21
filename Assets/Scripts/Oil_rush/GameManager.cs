using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool gameWon;
    public GameObject gameOverScreen = null;
    public GameObject oil_pump;
    public PipeDetectsOil value;
   // public PipeDetectsOil percentDone;
    public GameObject levelCompleteScreen = null;

    void Start()
    {
      
        Time.timeScale = 1;
        gameOver = false;
        gameWon = false;

 
    }

    void Update()
    {
        Debug.Log(gameWon);

        //Game Over
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
         
        }
        if (gameWon)
        {
            Time.timeScale = 0;
            levelCompleteScreen.SetActive(true);
        }

    }

}
