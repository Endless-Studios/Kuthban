using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class StopWatch : MonoBehaviour
{
    public bool paused = false;
    float currentTime;
    public float startMinutes;
    public Text currentTimeText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (paused) return;
        currentTime += Time.unscaledDeltaTime;
        //if(currentTime <= 0)
        //    GameManager.gameOver = true;

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        // currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString();
        //currentTimeText.enabled = true;
        currentTimeText.text = time.ToString(@"mm\:ss\.fff");
    }
}
