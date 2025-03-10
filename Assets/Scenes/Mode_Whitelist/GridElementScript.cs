using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElementScript : MonoBehaviour
{
    public bool isActive;
    public UnityEngine.UI.Image buttonImage; // Reference to the button's image component
    public List<Sprite> whitelistTrueImages; // List of images from WhitelistTrue
    public List<Sprite> whitelistFalseImages; // List of images from WhitelistFalse

    void Start()
    {
        AssignRandomImage();
    }

    // Function to assign a random image based on the isActive state
    void AssignRandomImage()
    {
        if (isActive)
        {
            // Assign a random image from WhitelistTrue
            if (whitelistTrueImages.Count > 0)
            {
                int randomIndex = Random.Range(0, whitelistTrueImages.Count);
                buttonImage.sprite = whitelistTrueImages[randomIndex];
            }
        }
        else
        {
            // Assign a random image from WhitelistFalse
            if (whitelistFalseImages.Count > 0)
            {
                int randomIndex = Random.Range(0, whitelistFalseImages.Count);
                buttonImage.sprite = whitelistFalseImages[randomIndex];
            }
        }
    }

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
