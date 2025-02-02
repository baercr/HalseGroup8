using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class NameGenerator : MonoBehaviour
{
    public string namesFileName = "Names.txt";
    private string[] firstNames;
    private string[] lastNames;
    public TMP_Text nameText;

    void Start()
    {
        ReadNamesFromFile();
        string randomFullName = GenerateRandomFullName();
        nameText.text = "Full Name: " + randomFullName;
    }

    void ReadNamesFromFile()
    {
        string namesFilePath = Path.Combine(Application.dataPath, namesFileName);
        string[] lines = File.ReadAllLines(namesFilePath);
        firstNames = new string[3];
        lastNames = new string[3];

        for (int i = 0; i < 3; i++)
        {
            firstNames[i] = lines[i];
            lastNames[i] = lines[i + 3];
        }
    }

    string GenerateRandomFullName()
    {
        int firstNameIndex = Random.Range(0, firstNames.Length);
        int lastNameIndex = Random.Range(0, lastNames.Length);
        return firstNames[firstNameIndex] + " " + lastNames[lastNameIndex];
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
