using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupMenuController : MonoBehaviour
{
    public GameObject popupMenu; // Reference to the pre-created popup menu

    // Function to show the popup menu
    public void ShowPopupMenu(Vector3 position)
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
    public void RemoveSelectedElement(GameObject element)
    {
        if (element != null)
        {
            Debug.Log("Removing selected element.");
            Destroy(element);
        }
    }
}
