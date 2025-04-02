using System.Collections;
using UnityEngine;
using TMPro;

public class PopupMenuController : MonoBehaviour
{
    public GameObject popupMenu;            // Popup menu object
    public TextMeshProUGUI popupText;       // Feedback text
    public TextMeshProUGUI IncorrectGuessesLeft; // Remaining guess counter
    public GameObject gridParent;          // Parent object of grid
    public GridInst gridInitializer;       // Reference to GridInst for grid operations

    private int incorrectGuesses = 0;      // Track incorrect removals
    private const int MaxTries = 3;        // Maximum incorrect attempts

    public void ClosePopup()
    {
        popupMenu?.SetActive(false);
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

            // Refresh the grid after removing the active element
            if (gridInitializer != null)
            {
                gridInitializer.RefreshGrid();
            }
            else
            {
                Debug.LogWarning("GridInst reference is null. Cannot refresh the grid.");
            }
        }
        else
        {
            incorrectGuesses++;
            DisplayMessage("You have removed a corporate-approved application!", Color.red);
        }

        StartCoroutine(CheckGameOver());
    }

    private void DisplayMessage(string message, Color color)
    {
        popupText.text = message;
        popupText.color = color;
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

    private void Update()
    {
        IncorrectGuessesLeft.text = $"Incorrect Guesses Left: {MaxTries - incorrectGuesses}";
    }
}
