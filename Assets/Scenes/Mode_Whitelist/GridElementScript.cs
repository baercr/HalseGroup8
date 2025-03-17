using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElementScript : MonoBehaviour
{
    public bool isActive;
    public UnityEngine.UI.Image buttonImage; // Reference to the button's image component
    public List<Sprite> whitelistTrueImages; // List of images from WhitelistTrue
    public List<Sprite> whitelistFalseImages; // List of images from WhitelistFalse

    public GameObject popupMenu; // Reference to the pre-created popup menu
    private static GridElementScript selectedElement; // To track the currently selected element

    void Start()
    {
        AssignRandomImage();
        if (popupMenu != null)
        {
            popupMenu.SetActive(false); // Ensure the popup menu is hidden initially
        }
    }

    // Function to assign a random image based on the isActive state
    void AssignRandomImage()
    {
        if (isActive)
        {
            if (whitelistTrueImages.Count > 0)
            {
                int randomIndex = Random.Range(0, whitelistTrueImages.Count);
                buttonImage.sprite = whitelistTrueImages[randomIndex];
            }
        }
        else
        {
            if (whitelistFalseImages.Count > 0)
            {
                int randomIndex = Random.Range(0, whitelistFalseImages.Count);
                buttonImage.sprite = whitelistFalseImages[randomIndex];
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
            // Activate the popup menu and position it at the mouse click location
            popupMenu.SetActive(true);
            RectTransform rectTransform = popupMenu.GetComponent<RectTransform>();
            Vector2 anchoredPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                popupMenu.transform.parent.GetComponent<RectTransform>(),
                position,
                null,
                out anchoredPosition
            );
            rectTransform.anchoredPosition = anchoredPosition;

            Debug.Log("Popup menu displayed.");
        }
        else
        {
            Debug.LogError("Popup menu reference is missing!");
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
