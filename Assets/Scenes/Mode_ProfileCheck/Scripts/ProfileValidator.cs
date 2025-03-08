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


    // Start is called before the first frame update
    void Start()
    {
        tpButton.onClick.AddListener(() => CheckProfile(false));
        fpButton.onClick.AddListener(() => CheckProfile(true));
    }

    void CheckProfile(bool isTP)
    {
        bool isValid = ValidateProfile();

        if(isTP && isValid)
        {
            feedbackText.text = "Correct! This profile is FP.";
            feedbackText.color = Color.green;
        }
        else if(!isTP && !isValid)
        {
            feedbackText.text = "Correct! This profile is TP.";
            feedbackText.color = Color.green;
        }
        else
        {
            feedbackText.text = "Incorrect. Try again.";
            feedbackText.color = Color.red;
        }
    }

    bool ValidateProfile()
    {
        return IsUsernameValid() && IsCountryVaild() && IsWorkHoursValid();
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

    bool IsCountryVaild()
    {
        return country == "United States";
    }

    bool IsWorkHoursValid()
    {
        string[] hours = workHours.Split('-');
        if (hours.Length != 2) return false;

        if (int.TryParse(hours[0], out int startHour) && int.TryParse(hours[1], out int endHour))
        {
            return startHour >= 8 && endHour <= 17;
        }

        return false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
