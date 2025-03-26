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
    public GameObject panelConfirmation;
    public GameObject panelSOP;


    void Start()
    {
        panelResults.SetActive(false);
        panelConfirmation.SetActive(false);
        panelSOP.SetActive(false);
        
        currentTime = startTimeInSeconds;
        UpdateCountupText();
    }

    void Update()
    {
        if (currentTime < 580) //8:00 start time = 480 , 16:00 or 8 minutes = 960 , 8:03 or 3 seconds = 483 
        {
            //Debug.Log(currentTime);
            currentTime += Time.deltaTime;
            UpdateCountupText();
        }
        
        else
        {
            panelResults.SetActive(true);
            panelConfirmation.SetActive(false);
            panelSOP.SetActive(false);
        }
    }

    void UpdateCountupText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        countupText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

