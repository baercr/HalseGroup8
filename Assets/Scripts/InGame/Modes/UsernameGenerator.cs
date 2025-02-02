using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsernameGenerator : MonoBehaviour
{
    void Start()
    {
        string username = GenerateRandomUsername();
        Debug.Log("Username: " + username);
    }

    string GenerateRandomUsername()
    {
        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string digits = "0123456789";

        string randomUsername = "";
        randomUsername += letters[Random.Range(0, letters.Length)];
        randomUsername += letters[Random.Range(0, letters.Length)];
        randomUsername += digits[Random.Range(0, digits.Length)];
        randomUsername += digits[Random.Range(0, digits.Length)];

        return randomUsername;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
