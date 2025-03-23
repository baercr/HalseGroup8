using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridElementScript : MonoBehaviour
{
    public bool isActive;
    public UnityEngine.UI.Image buttonImage; // Reference to the button's image component
    public List<Sprite> whitelistTrueImages; // List of images from WhitelistTrue
    public List<Sprite> whitelistFalseImages; // List of images from WhitelistFalse
    private static List<Sprite> usedTrueImages = new List<Sprite>(); // Track used images from WhitelistTrue
    private static List<Sprite> usedFalseImages = new List<Sprite>(); // Track used images from WhitelistFalse
    public static GridElementScript selectedElement; // To track the currently selected element

    void Start()
    {
        AssignUniqueImage();
    }

    void AssignUniqueImage()
    {
        if (isActive)
        {
            AssignImageFromList(whitelistTrueImages, usedTrueImages);
        }
        else
        {
            AssignImageFromList(whitelistFalseImages, usedFalseImages);
        }
    }

    void AssignImageFromList(List<Sprite> sourceList, List<Sprite> usedList)
    {
        if (sourceList.Count > 0)
        {
            if (usedList.Count == sourceList.Count)
            {
                usedList.Clear();
            }

            List<Sprite> availableImages = new List<Sprite>(sourceList);
            availableImages.RemoveAll(sprite => usedList.Contains(sprite));

            if (availableImages.Count > 0)
            {
                int randomIndex = Random.Range(0, availableImages.Count);
                Sprite selectedImage = availableImages[randomIndex];

                buttonImage.sprite = selectedImage;
                usedList.Add(selectedImage);
            }
        }
    }

    public void OnElementClick()
    {
        if (selectedElement != null)
        {
            Debug.Log("Deselecting the previous element.");
        }

        selectedElement = this;
        Debug.Log("This element is now selected.");
    }
}

