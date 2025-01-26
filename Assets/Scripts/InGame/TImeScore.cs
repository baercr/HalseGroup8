using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownClock : MonoBehaviour
{
    public int startTimeInSeconds = 60; // Set the starting time in seconds
    private float currentTime;
    public TextMeshProUGUI countdownText; // Reference to the UI Text component

    void Start()
    {
        currentTime = startTimeInSeconds;
        UpdateCountupText();
    }

    void Update()
    {
        if (currentTime < 1440)
        {
            currentTime += Time.deltaTime;
            UpdateCountupText();
        }
        else
        {
            currentTime = 0;
            UpdateCountupText();
            // Optionally, add any actions to perform when the countdown reaches zero
        }
    }

    void UpdateCountupText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

