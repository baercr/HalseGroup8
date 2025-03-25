using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class PopupMenuController : MonoBehaviour
{
    // Reference to the popup menu UI object
    public GameObject popupMenu;

    public TextMeshProUGUI popupText;

    // Transform of the grid parent containing grid elements
    public Transform gridParent;

    private void Update()
    {
        // Check for a right-click event
        if (Input.GetMouseButtonDown(1)) // 1 corresponds to the right mouse button
        {
            // Display the popup menu at the pointer's position
            ShowPopup(Input.mousePosition);
        }
    }

    // Function to display the popup menu
    public void ShowPopup(Vector3 screenPosition)
    {
        if (popupMenu != null)
        {
            popupMenu.SetActive(true);

            // Convert screen position to world position in the canvas
            RectTransformUtility.ScreenPointToWorldPointInRectangle(
                popupMenu.GetComponentInParent<Canvas>().transform as RectTransform,
                screenPosition,
                Camera.main,
                out Vector3 worldPosition);

            popupMenu.transform.position = worldPosition;
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
                popupText.text = "successfully removed the non-approved software!";
                popupText.color = Color.green;
                Debug.Log("You have successfully removed the non-approved software!");
            }
            else
            {
                popupText.text = "you have removed a corporate-approved application!";
                popupText.color = Color.red;
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
