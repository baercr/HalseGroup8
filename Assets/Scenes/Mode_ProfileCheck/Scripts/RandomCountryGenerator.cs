using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomCountryGenerator : MonoBehaviour
{
    public TMP_Text countryText;
    private List<string> countries = new List<string>
    {
        "United States", "Russia", "China", "Scamdinavia", "Iraq"
    };


    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomCountry();
    }

    public string GenerateRandomCountry()
    {
        int randomIndex = Random.Range(0, countries.Count);
        string randomCountry = countries[randomIndex];
        countryText.text = "Location: " + randomCountry;
        return randomCountry;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
