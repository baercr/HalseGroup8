using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElementScript : MonoBehaviour
{
    public bool isActive;
    public UnityEngine.UI.Image buttonImage; // Reference to the button's image component
    public List<Sprite> whitelistTrueImages; // List of images from WhitelistTrue
    public List<Sprite> whitelistFalseImages; // List of images from WhitelistFalse

    private static List<Sprite> usedTrueImages = new List<Sprite>(); // Track used images from WhitelistTrue
    private static List<Sprite> usedFalseImages = new List<Sprite>(); // Track used images from WhitelistFalse

    public GameObject popupMenu; // Reference to the pre-created popup menu
    private static GridElementScript selectedElement; // To track the currently selected element

    void Start()
    {
        AssignUniqueImage();
        if (popupMenu != null)
        {
            popupMenu.SetActive(false); // Ensure the popup menu is hidden initially
        }
    }

    // Function to assign a unique image based on the isActive state
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

    // Helper function to assign a unique image and handle duplicates
    void AssignImageFromList(List<Sprite> sourceList, List<Sprite> usedList)
    {
        if (sourceList.Count > 0)
        {
            // Reset used list if all images have been used
            if (usedList.Count == sourceList.Count)
            {
                usedList.Clear();
            }

            // Find an unused image
            List<Sprite> availableImages = new List<Sprite>(sourceList);
            availableImages.RemoveAll(sprite => usedList.Contains(sprite));

            if (availableImages.Count > 0)
            {
                int randomIndex = Random.Range(0, availableImages.Count);
                Sprite selectedImage = availableImages[randomIndex];

                buttonImage.sprite = selectedImage;
                usedList.Add(selectedImage); // Mark as used
            }
        }
    }

    void Update()
    {
        // Detect right-click to display the popup menu
        if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            if (selectedElement == this)
            {
                ShowPopupMenu(Input.mousePosition);
            }
        }
    }

    // Function to handle selection of this grid element
    public void OnElementClick()
    {
        Debug.Log("Element clicked");

        // Deselect previous element if any
        if (selectedElement != null)
        {
            Debug.Log("Deselecting the previous element.");
        }

        // Select this element
        selectedElement = this;
        Debug.Log("This element is now selected.");
    }

    // Function to show the popup menu
    private void ShowPopupMenu(Vector3 position)
    {
        if (popupMenu != null)
        {
            Debug.Log("Activating popup menu.");
            popupMenu.SetActive(true); // Activates the popup menu
            popupMenu.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, Camera.main.nearClipPlane)); // Sets its position
            Debug.Log("Popup menu is now active at position: " + position);
        }
        else
        {
            Debug.LogError("Popup menu reference is null!");
        }
    }

    // Function to hide the popup menu
    public void HidePopupMenu()
    {
        if (popupMenu != null)
        {
            popupMenu.SetActive(false);
        }
    }

    // Function to remove the selected grid element
    public void RemoveElement()
    {
        if (selectedElement == this)
        {
            Debug.Log("Removing selected element.");
            Destroy(gameObject);
        }
    }
}
