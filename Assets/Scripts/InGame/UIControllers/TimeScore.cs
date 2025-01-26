using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownClock : MonoBehaviour
{
    public int startTimeInSeconds = 0; // Set the starting time in seconds
    private float currentTime;

    public TextMeshProUGUI countupText; // Reference to the UI Text component

    public GameObject panelResults;
    public GameObject panelTools;
    public GameObject panelConfirmation;
    public GameObject panelSOP;
    public GameObject panelTicketQueue;


    void Start()
    {
        panelResults.SetActive(false);
        currentTime = startTimeInSeconds;
        UpdateCountupText();
    }

    void Update()
    {
        if (currentTime < 960)
        {
            Debug.Log(currentTime);
            currentTime += Time.deltaTime;
            UpdateCountupText();
        }
        
        else
        {
            panelResults.SetActive(true);
            panelTools.SetActive(false);
            panelConfirmation.SetActive(false);
            panelSOP.SetActive(false);
            panelTicketQueue.SetActive(false);
        }
    }

    void UpdateCountupText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        countupText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

