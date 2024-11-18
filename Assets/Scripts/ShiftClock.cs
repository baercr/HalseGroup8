using UnityEngine;
using UnityEngine.UI;

public class CountdownClock : MonoBehaviour
{
    public int startTimeInSeconds = 60; // Set the starting time in seconds
    private float currentTime;
    public Text countdownText; // Reference to the UI Text component

    void Start()
    {
        currentTime = startTimeInSeconds;
        UpdateCountdownText();
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateCountdownText();
        }
        else
        {
            currentTime = 0;
            UpdateCountdownText();
            // Optionally, add any actions to perform when the countdown reaches zero
        }
    }

    void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

