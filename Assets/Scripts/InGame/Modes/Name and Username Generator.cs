using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class NameandUsernameGenerator : MonoBehaviour
{

    public string namesFilePath = "Names.txt";
    private string[] firstNames;
    private string[] lastNames;

    void Start()
    {
        ReadNamesFromFile();
        string randomFullName = GenerateRandomFullName();
        string randomUsername = GenerateRandomUsername();
        Debug.Log("Random Full Name: " + randomFullName);
        Debug.Log("Random Username: " + randomUsername);

    }

    void ReadNamesFromFile()
    {
        string[] lines = File.ReadAllLines(namesFilePath);
        firstNames = lines.Take(3).ToArray();
        lastNames = lines.Skip(3).Take(3).ToArray();
    }

    string GenerateRandomFullName()
    {
        int firstNameIndex = Random.Range(0, firstNames.Length);
        int lastNameIndex = Random.Range(0, lastNames.Length);
        return firstNames[firstNameIndex] + " " + lastNames[lastNameIndex];
    }

    string GenerateRandomUsername()
    {
        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string digits = "0123456789";

        string randomUsername = " ";
        randomUsername += letters[Random.Range(0, letters.Length)];
        randomUsername += letters[Random.Range(0, letters.Length)];
        randomUsername += digits[Random.Range(0, digits.Length)];
        randomUsername += digits[Random.Range(0, digits.Length)];

        return randomUsername; 

    }


    void Update()
    {
        
    }
}
