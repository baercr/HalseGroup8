using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProfileValidator : MonoBehaviour
{
    public string username;
    public string country;
    public string workHours;

    public Button tpButton;
    public Button fpButton;
    public TMP_Text feedbackText;

    public Image cbody;
    public Image cface;
    public Image chair;
    public Image ckit;

    public TMP_Text fullNameText;
    public TMP_Text usernameText;
    public TMP_Text locationText;
    public TMP_Text workHoursText;

    public NameAndUsernameGenerator nameAndUsernameGenerator;
    public RandomCountryGenerator randomCountryGenerator;
    public RandomTimeStamp randomTimeStamp;
    public RandomSample randomSample;

    // Start is called before the first frame update
    void Start()
    {
        tpButton.onClick.AddListener(() => CheckProfile(false));
        fpButton.onClick.AddListener(() => CheckProfile(true));
        GenerateNewProfile();
    }

    void CheckProfile(bool isTP)
    {
        bool isValid = ValidateProfile();

        if (isTP && isValid)
        {
            feedbackText.text = "Correct! This profile is FP.";
            feedbackText.color = Color.green;
            StartCoroutine(ShowFeedbackAndGenerateNewProfile());
        }
        else if (!isTP && !isValid)
        {
            feedbackText.text = "Correct! This profile is TP.";
            feedbackText.color = Color.green;
            StartCoroutine(ShowFeedbackAndGenerateNewProfile());
        }
        else
        {
            feedbackText.text = "Incorrect. Try again.";
            feedbackText.color = Color.red;
        }
    }

    bool ValidateProfile()
    {
        return IsUsernameValid() && IsCountryValid() && IsWorkHoursValid();
    }

    bool IsUsernameValid()
    {
        int letterCount = 0;
        int numberCount = 0;

        foreach (char c in username)
        {
            if (char.IsLetter(c)) letterCount++;
            if (char.IsDigit(c)) numberCount++;
        }

        return letterCount == 2 && numberCount == 2;
    }

    bool IsCountryValid()
    {
        return country == "United States";
    }

    bool IsWorkHoursValid()
    {
        if(DateTime.TryParseExact(workHours, "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime time))
        {
            int hour = time.Hour;
            return hour >= 8 && hour <= 17;
        }
        return false;
    }

    IEnumerator ShowFeedbackAndGenerateNewProfile()
    {
        yield return new WaitForSeconds(4);
        feedbackText.text = "";
        GenerateNewProfile();
        
    }

    void GenerateNewProfile()
    {
        string randomFullName = nameAndUsernameGenerator.GenerateRandomFullName();
        username = nameAndUsernameGenerator.GenerateRandomUsername();
        country = randomCountryGenerator.GenerateRandomCountry();
        workHours = randomTimeStamp.GenerateRandomTimeStamp();

        fullNameText.text = "Full Name: " + randomFullName;
        usernameText.text = "Username: " + username;
        locationText.text = "Country: " + country;
        workHoursText.text = "Time Stamp: " + workHours;

        randomSample.RandomizeCharacter();

        cbody.sprite = randomSample.cbody.sprite;
        chair.sprite = randomSample.chair.sprite;
        cface.sprite = randomSample.cface.sprite;
        ckit.sprite = randomSample.ckit.sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
