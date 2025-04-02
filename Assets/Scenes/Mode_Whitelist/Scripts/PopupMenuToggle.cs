using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IPopupMenuToggle
{
    void ClosePopup();
    void ShowPopup(Vector3 screenPosition);
}

public class PopupMenuToggle : MonoBehaviour, IPopupMenuToggle
{
    public GameObject popupmenu;

    private void Update()
    {
        // Check for a right-click event
        if (Input.GetMouseButtonDown(1)) 
        {
            ShowPopup(Input.mousePosition);
        }

        // Check for a left-click event and close the popup if the click is outside
        if (Input.GetMouseButtonDown(0)) 
        {
            if (popupmenu.activeSelf && !IsPointerOverUIElement())
            {
                ClosePopup();
            }
        }
    }

    // Function to display the popup menu
    public void ShowPopup(Vector3 screenPosition)
    {
        if (popupmenu != null)
        {
            popupmenu.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Popup menu is not assigned.");
        }
    }

    // Function to close the popup menu
    public void ClosePopup()
    {
        if (popupmenu != null)
        {
            popupmenu.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Popup menu reference is null.");
        }
    }

    // Helper method to check if pointer is over a UI element
    private bool IsPointerOverUIElement()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        // Check if any UI element in the results matches the popup menu or its children
        foreach (var result in results)
        {
            if (result.gameObject == popupmenu || popupmenu.transform.IsChildOf(result.gameObject.transform))
            {
                return true;
            }
        }

        return false;
    }
}
