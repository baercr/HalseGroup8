using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public GameObject panelSOP; // The panel you want to show/hide
    public Button buttonSOP; // The button that acts as the tab

    public GameObject panelConfirmation; // The panel you want to show/hide
    public Button buttonConfirmation; // The button that acts as the tab


    void Start()
    {
        // SOP //
        // Ensure the panel is initially hidden
        panelSOP.SetActive(false);

        // Add a listener to the button to call the TogglePanel function when clicked
        buttonSOP.onClick.AddListener(ToggleSOP);


        // Confirmation TP/FP //
        // Ensure the panel is initially hidden
        panelConfirmation.SetActive(false);

        // Add a listener to the button to call the TogglePanel function when clicked
        buttonConfirmation.onClick.AddListener(ToggleConfirmation);
    }

    void ToggleSOP()
    {
        // Toggle the panel's active state
        panelSOP.SetActive(!panelSOP.activeSelf);
    }

    void ToggleConfirmation()
    {
        // Toggle the panel's active state
        panelConfirmation.SetActive(!panelConfirmation.activeSelf);
    }
}
