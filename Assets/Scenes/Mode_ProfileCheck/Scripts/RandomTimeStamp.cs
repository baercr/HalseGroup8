using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomTimeStamp : MonoBehaviour
{
    public TMP_Text timeText;


    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomTimeStamp();
    }

    void GenerateRandomTimeStamp()
    {
        int randomHour = Random.Range(1, 25);
        string militaryTime = randomHour.ToString("D2") + ":00";
        timeText.text = "Time Stamp: " + militaryTime;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
