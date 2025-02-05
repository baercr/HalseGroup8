using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftwareWhitelist : MonoBehaviour
{
    public Texture2D[] images; // Assign images in the Unity Inspector
    private bool[,] appArray = new bool[5, 5];
    private Texture2D[,] imageArray = new Texture2D[5, 5];

    public GameObject WhitelistImage;

    void Start()
    {
        // Initialize appArray with true (approved/whitelisted)
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                appArray[i, j] = true;
                // Assign images to imageArray
                imageArray[i, j] = images[Random.Range(0, images.Length)];
            }
        }

        // Run random number generators
        int row = Random.Range(0, 5);
        int column = Random.Range(0, 5);

        Debug.Log("Target app at row: " + row + " column: " + column);

        // Change the selected app to false (not whitelisted)
        appArray[row, column] = false;

        // Print the array status to the console
        PrintArray();
    }

    void PrintArray()
    {
        for (int i = 0; i < 5; i++)
        {
            string row = "";
            for (int j = 0; j < 5; j++)
            {
                row += appArray[i, j] ? "1 " : "0 ";
            }
            Debug.Log(row);
        }
    }
}

