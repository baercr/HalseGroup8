using UnityEngine;

public class PopupMenu : MonoBehaviour
{
    private GameObject selectedGridElement;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                // Check if the clicked object is a grid element
                if (hit.collider.gameObject.CompareTag("GridElement"))
                {
                    selectedGridElement = hit.collider.gameObject;
                    ShowPopupMenu(mousePosition);
                }
            }
        }
    }

    private void ShowPopupMenu(Vector3 position)
    {
        GameObject popupMenu = GameObject.Find("PopupMenu");
        popupMenu.SetActive(true);
        popupMenu.transform.position = Camera.main.WorldToScreenPoint(position);
    }

    public void RemoveGridElement()
    {
        if (selectedGridElement != null)
        {
            Destroy(selectedGridElement);
            ClosePopupMenu();
        }
    }

    public void IgnoreAction()
    {
        // Perform any logic for the ignore action
        Debug.Log("Ignore button clicked");
        ClosePopupMenu();
    }

    private void ClosePopupMenu()
    {
        GameObject popupMenu = GameObject.Find("PopupMenu");
        popupMenu.SetActive(false);
        selectedGridElement = null;
    }
}
