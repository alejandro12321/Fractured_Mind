using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float totalTime;
    public TextMeshProUGUI timerText;
    public GameObject gameOverObject;

    private float currentTime;
    private Coroutine countdownCoroutine;

    private void Start()
    {
        totalTime = 900f;
        currentTime = totalTime;
        StartCountdown();
    }

    private void StartCountdown()
    {
        if (countdownCoroutine != null)
            StopCoroutine(countdownCoroutine);

        countdownCoroutine = StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;

            TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);
            string timeFormatted = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
            timerText.text = timeFormatted;
            yield return null;
        }

        currentTime = 0f;
        TimeUp();
    }

    private void TimeUp()
    {
        // Activate the gameOverObject
        gameOverObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void RestartScene()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
