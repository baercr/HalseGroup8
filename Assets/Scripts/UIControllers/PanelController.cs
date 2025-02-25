using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public GameObject panelTicketQueue; // The panel you want to show/hide
    public Button buttonTicketQueue; // The button that acts as the tabv

    public GameObject panelSOP; // The panel you want to show/hide
    public Button buttonSOP; // The button that acts as the tab

    public GameObject panelConfirmation; // The panel you want to show/hide
    public Button buttonConfirmation; // The button that acts as the tab

    public GameObject panelTools; // The panel you want to show/hide
    public Button buttonTools; // The button that acts as the tab

    void Start()
    {
        // Ticket Queue //
        // Ensure the panel is initially hidden
        panelTicketQueue.SetActive(false);

        // Add a listener to the button to call the TogglePanel function when clicked
        buttonTicketQueue.onClick.AddListener(ToggleTicketQueue);


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


        // Tools //
        // Ensure the panel is initially hidden
        panelTools.SetActive(false);

        // Add a listener to the button to call the TogglePanel function when clicked
        buttonTools.onClick.AddListener(ToggleTools);
    }

    private void Update()
    {
        
    }


    void ToggleTicketQueue()
    {
        // Toggle the panel's active state
        panelTicketQueue.SetActive(!panelTicketQueue.activeSelf);
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

    void ToggleTools()
    {
        // Toggle the panel's active state
        panelTools.SetActive(!panelTools.activeSelf);
    }
}
