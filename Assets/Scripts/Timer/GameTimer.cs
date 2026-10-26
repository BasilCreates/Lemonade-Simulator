using System;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField]
    private Text TimerText;

    [SerializeField]
    private float timeRemaining = 1200;

    [SerializeField]
    private int timeElapsed = 1;

    [SerializeField]
    private float gameOverTime = 0.9f;

    [SerializeField]
    private bool isTimerRunning = true;

    public event Action OnTimerEnd;




    private void Update()
    {
        if (isTimerRunning)
        {
            TimerCountdown();
        }
    }



    public void TimerCountdown()
    {
        if (timeRemaining <= gameOverTime)
        {
            isTimerRunning = false;
            OnTimerEnd?.Invoke();
        }
        else
        {
            timeRemaining -= timeElapsed * Time.deltaTime;

            int timeCountingDown = ((int)timeRemaining);
            TimerText.text = timeCountingDown.ToString();
        }

    }
}




