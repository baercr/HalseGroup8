using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoftwareWhitelistController : MonoBehaviour
{
    public GameObject SoftwareWhitelistGrid; // The panel you want to show/hide
    public Button buttonToggle; // The button that acts as the tab

    void Start()
    {
        // Ensure the panel is initially hidden
        SoftwareWhitelistGrid.SetActive(false);

        // Add a listener to the button to call the TogglePanel function when clicked
        buttonToggle.onClick.AddListener(TogglePanel);
    }

    void TogglePanel()
    {
        // Toggle the panel's active state
        SoftwareWhitelistGrid.SetActive(!SoftwareWhitelistGrid.activeSelf);
    }
}

