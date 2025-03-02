using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NameAndUsernameGenerator : MonoBehaviour
{
    public string namesFileName = "Names.txt";
    private string[] firstNames;
    private string[] lastNames;
    public TMP_Text nameText;
    public TMP_Text usernameText;

    public Button tpButton;
    public Button fpButton;

    private string generatedFirstName;
    private string generatedLastName;
    private string currentUsername;
    private bool isRealUsername;

    void Start()
    {
        ReadNamesFromFile();
        string randomFullName = GenerateRandomFullName();
        nameText.text = "Full Name: " + randomFullName;

        string randomUsername = GenerateRandomUsername();
        usernameText.text = "Username: " + randomUsername;

        tpButton.onClick.AddListener(OnTPButtonClick);
        fpButton.onClick.AddListener(OnFPButtonClick);
    }

    void ReadNamesFromFile()
    {
        string namesFilePath = Path.Combine(Application.dataPath, "Scenes", "Mode_ProfileCheck", namesFileName);
        string[] lines = File.ReadAllLines(namesFilePath);
        firstNames = new string[3];
        lastNames = new string[3];

        for (int i = 0; i < 3; i++)
        {
            firstNames[i] = lines[i];
            lastNames[i] = lines[i + 3];
        }
    }

    void GenerateRandomProfile()
    {
        string randomFullName = GenerateRandomFullName();
        nameText.text = "Full Name: " + randomFullName;

        string randomUsername = GenerateRandomUsername();
        usernameText.text = "Username: " + randomUsername;
    }

    string GenerateRandomFullName()
    {
        int firstNameIndex = Random.Range(0, firstNames.Length);
        int lastNameIndex = Random.Range(0, lastNames.Length);
        generatedFirstName = firstNames[firstNameIndex];
        generatedLastName = lastNames[lastNameIndex];
        return generatedFirstName + " " + generatedLastName;
    }

    string GenerateRandomUsername()
    {
        string digits = "0123456789";
        string firstLetter = generatedFirstName.Substring(0, 1).ToUpper();
        string lastLetter = generatedLastName.Substring(0, 1).ToUpper();

        string randomDigits = "";
        randomDigits += digits[Random.Range(0, digits.Length)];
        randomDigits += digits[Random.Range(0, digits.Length)];

        string currentusername = firstLetter + lastLetter + randomDigits;

        bool isRealUsername = Random.Range(0f, 1f) < 0.4f;
        if (isRealUsername)
        {
            int faultyType = Random.Range(0, 2);
            switch (faultyType)
            {
                case 0:
                    currentUsername = firstLetter + firstLetter[Random.Range(0, firstLetter.Length)] + lastLetter + randomDigits;
                    break;
                case 1:
                    currentUsername = firstLetter + lastLetter + randomDigits + digits[Random.Range(0, digits.Length)];
                    break;
            }
        }

        return currentUsername;

    }

    public void OnTPButtonClick()
    {
        Debug.Log("TP Button Clicked");
        ValidateUsername(true);

    }

    public void OnFPButtonClick()
    {
        Debug.Log("FP Button Clicked");
        ValidateUsername(false);
    }

    void ValidateUsername(bool isTP)
    {
        if (isTP == isRealUsername)
        {
            Debug.Log("The username valudation is accurate");
        }

        else
        {
            Debug.Log("The username validation is inaccurate");
        }

        GenerateRandomProfile();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
