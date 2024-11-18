using UnityEngine;
using UnityEngine.UI;

public class ToolPanelController : MonoBehaviour
{
    public GameObject panelTools; // The panel you want to show/hide
    public Button buttonToggle; // The button that acts as the tab

    void Start()
    {
        // Ensure the panel is initially hidden
        panelTools.SetActive(false);

        // Add a listener to the button to call the TogglePanel function when clicked
        buttonToggle.onClick.AddListener(TogglePanel);
    }

    void TogglePanel()
    {
        // Toggle the panel's active state
        panelTools.SetActive(!panelTools.activeSelf);
    }
}
