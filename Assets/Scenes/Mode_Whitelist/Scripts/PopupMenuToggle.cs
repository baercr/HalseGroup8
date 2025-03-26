using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public interface IPopupMenuToggle
{
    void ClosePopup();
    void ShowPopup(Vector3 screenPosition);
}

public class PopupMenuToggle : MonoBehaviour, IPopupMenuToggle
{
    public GameObject popupmenu;
    // Update is called once per frame
    private void Update()
    {
        // Check for a right-click event
        if (UnityEngine.Input.GetMouseButtonDown(1)) // 1 corresponds to the right mouse button
        {
            // Display the popup menu at the pointer's position
            ShowPopup(UnityEngine.Input.mousePosition);
        }
    }

    // Function to display the popup menu
    public void ShowPopup(Vector3 screenPosition)
    {
        if (popupmenu != null)
        {
            popupmenu.SetActive(true);

            // Convert screen position to world position in the canvas
            RectTransformUtility.ScreenPointToWorldPointInRectangle(
                popupmenu.GetComponentInParent<Canvas>().transform as RectTransform,
                screenPosition,
                Camera.main,
                out Vector3 worldPosition);

            popupmenu.transform.position = worldPosition;
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
}