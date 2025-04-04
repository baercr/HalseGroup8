using System.Collections;
using UnityEngine;
using TMPro;

public class PopupMenuController : MonoBehaviour
{
    public GameObject popupMenu;                 // Popup menu object
    public TextMeshProUGUI popupText;            // Feedback text
    public TextMeshProUGUI IncorrectGuessesLeft; // Remaining guesses UI text
    public GameObject gridParent;               // Parent object of the grid
    public GridInst gridInitializer;            // Reference to GridInst

    private int incorrectGuesses = 0;           // Tracks incorrect removals
    private const int MaxTries = 7;             // Maximum incorrect attempts

    private void Start()
    {
        // Initialize the incorrect guesses text when the game starts
        UpdateIncorrectGuessesText();
    }

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

    public void RemoveSelectedElement()
    {
        if (GridElementScript.selectedElement == null)
        {
            DisplayMessage("No App was selected to remove!", Color.red);
            return;
        }

        bool isActive = GridElementScript.selectedElement.isActive;
        Destroy(GridElementScript.selectedElement.gameObject);
        GridElementScript.selectedElement = null;

        if (isActive)
        {
            DisplayMessage("Successfully removed the non-approved software!", Color.green);

            // Refresh the grid after removing an active element
            gridInitializer?.RefreshGrid();
        }
        else
        {
            incorrectGuesses++; // Increment incorrect guesses
            UpdateIncorrectGuessesText(); // Update UI text
            DisplayMessage("You have removed a corporate-approved application!", Color.red);
        }

        StartCoroutine(CheckGameOver());
    }

    private void UpdateIncorrectGuessesText()
    {
        if (IncorrectGuessesLeft != null)
        {
            // Update the text to reflect remaining attempts
            IncorrectGuessesLeft.text = $"Incorrect Guesses Left: {MaxTries - incorrectGuesses}";
            Debug.Log($"IncorrectGuessesLeft updated: {IncorrectGuessesLeft.text}");
        }
        else
        {
            Debug.LogError("IncorrectGuessesLeft TextMeshPro reference is missing in the Inspector!");
        }
    }

    private void DisplayMessage(string message, Color color)
    {
        if (popupText != null)
        {
            popupText.text = message;
            popupText.color = color;
        }
        else
        {
            Debug.LogError("popupText reference is missing!");
        }
    }

    private IEnumerator CheckGameOver()
    {
        yield return new WaitForSeconds(1);
        popupText.text = "";

        if (incorrectGuesses >= MaxTries)
        {
            DisplayMessage("Game Over. You've run out of attempts!", Color.red);
            popupText.fontSize = 45;
            gridParent.SetActive(false);
        }
    }
}
