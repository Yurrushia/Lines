using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    bool timerActive = true;
    float currentTime;
    public int startMinute;
    public Text currentTimeText;
    [SerializeField] private GameLost lostPanel;
    [SerializeField] private ExitGame exitPanel;
    void Start()
    {
        currentTime = startMinute * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive == true)
        {
            currentTime = currentTime - Time.deltaTime;
            if(currentTime <=0)
            {
                timerActive = false;
                Start();
                lostPanel.display(Game.points, false);
                Debug.Log("Game Over!");
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.Minutes.ToString() + ":" +time.Seconds.ToString();
    }

}
