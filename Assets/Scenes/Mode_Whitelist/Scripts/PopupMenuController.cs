using System.Collections.Generic;
using UnityEngine;

public class PopupMenuController : MonoBehaviour
{
    // Reference to the popup menu UI object
    public GameObject popupMenu;

    // Transform of the grid parent containing grid elements
    public Transform gridParent;

    // Function to display the popup menu
    public void ShowPopup(Vector3 position)
    {
        if (popupMenu != null)
        {
            popupMenu.SetActive(true);
            popupMenu.transform.position = position;
        }
        else
        {
            Debug.LogWarning("Popup menu is not assigned.");
        }
    }

    // Function to close the popup menu
    public void ClosePopup()
    {
        if (popupMenu != null)
        {
            popupMenu.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Popup menu reference is null.");
        }
    }

    // Function to remove the selected grid element
    public void RemoveSelectedElement()
    {
        if (GridElementScript.selectedElement != null)
        {
            // Determine if the selected element is active or inactive
            bool isActive = GridElementScript.selectedElement.isActive;

            // Destroy the selected grid element
            Destroy(GridElementScript.selectedElement.gameObject);

            // Display a message based on the state of the removed element
            if (isActive)
            {
                Debug.Log("You have successfully removed the non-approved software!");
            }
            else
            {
                Debug.Log("Unfortunately, you have removed a corporate-approved application.");
            }

            // Clear the selected element
            GridElementScript.selectedElement = null;

            // Close the popup menu
            ClosePopup();
        }
        else
        {
            Debug.LogWarning("No element is selected to remove.");
        }
    }
}
