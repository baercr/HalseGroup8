using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElementScript : MonoBehaviour
{
    public bool isActive;

    // Example: Function to handle button click
    public void OnButtonClick()
    {
         Debug.Log("Button clicked");
        if (isActive)
        {
            Debug.Log("This is the active element!");
        }
        else
        {
            Debug.Log("This is not the active element.");
        }
    }
}