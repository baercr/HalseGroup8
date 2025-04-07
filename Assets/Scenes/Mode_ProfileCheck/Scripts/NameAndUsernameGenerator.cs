using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class NameAndUsernameGenerator : MonoBehaviour
{
    private string[] firstNames = new string[]
    {
        "Cameron", "Alex", "Bailey", "Drew", "Charlie"
    };

    private string[] lastNames = new string[]
    {
        "Smith", "Johnson", "Wilson", "Miller", "Davis"
    };
    
    public TMP_Text nameText;
    public TMP_Text usernameText;

    private string generatedFirstName;
    private string generatedLastName;

    void Start()
    {
        string randomFullName = GenerateRandomFullName();
        nameText.text = "Full Name: " + randomFullName;

        string randomUsername = GenerateRandomUsername();
        usernameText.text = "Username: " + randomUsername;
    }

    public string GenerateRandomFullName()
    {
        int firstNameIndex = Random.Range(0, firstNames.Length);
        int lastNameIndex = Random.Range(0, lastNames.Length);
        generatedFirstName = firstNames[firstNameIndex];
        generatedLastName = lastNames[lastNameIndex];
        return generatedFirstName + " " + generatedLastName;
    }

    public string GenerateRandomUsername()
    {
        string digits = "0123456789";
        string firstLetter = generatedFirstName.Substring(0, 1).ToUpper();
        string lastLetter = generatedLastName.Substring(0, 1).ToUpper();

        string randomDigits = "";
        randomDigits += digits[Random.Range(0, digits.Length)];
        randomDigits += digits[Random.Range(0, digits.Length)];

        string randomUsername = firstLetter + lastLetter + randomDigits;

        bool isFaulty = Random.Range(0f, 1f) < 0.4f;
        if (isFaulty)
        {
            int faultyType = Random.Range(0, 2);
            switch (faultyType)
            {
                case 0:
                    randomUsername = firstLetter + firstLetter[Random.Range(0, firstLetter.Length)] + lastLetter + randomDigits;
                    break;
                case 1:
                    randomUsername = firstLetter + lastLetter + randomDigits + digits[Random.Range(0, digits.Length)];
                    break;
            }
        }

        return randomUsername;

    }

}
