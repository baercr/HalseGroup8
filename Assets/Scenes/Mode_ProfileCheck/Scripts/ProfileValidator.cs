using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileValidator : MonoBehaviour
{
    public string username;
    public string country;
    public string workHours;

    public Button tpButton;
    public Button fpButton;

    // Start is called before the first frame update
    void Start()
    {
        tpButton.onClick.AddListener(() => CheckProfile(true));
        fpButton.onClick.AddListener(() => CheckProfile(false));
    }

    void CheckProfile(bool isTP)
    {
        bool isValid = ValidateProfile();

        if(isTP && isValid)
        {
            Debug.Log("This profile is TP.");
        }
        else if(!isTP && !isValid)
        {
            Debug.Log("This profile is FP.");
        }
        else
        {
            Debug.Log("Incorrect. Try again.");
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
