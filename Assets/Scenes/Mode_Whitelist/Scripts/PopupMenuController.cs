using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopupMenuController : MonoBehaviour
{
    public GameObject popupMenu;
    public TextMeshProUGUI popupText;
    public TextMeshProUGUI IncorrectGuessesLeft;
    public Transform gridParent;

    private int IncorrectGuesses = 0;
    private int MaxTries = 5;
    private int attemptsLeft;
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
        if (GridElementScript.selectedElement != null)
        {
            bool isActive = GridElementScript.selectedElement.isActive;

            Destroy(GridElementScript.selectedElement.gameObject);

            if (isActive)
            {
                popupText.text = "Successfully removed the non-approved software!";
                popupText.color = Color.green;
                StartCoroutine(ShowWhitelistFeedback());
                Debug.Log("You have successfully removed the non-approved software!");
            }
            else
            {
                IncorrectGuesses++;
                UpdateAttemptsInfo(); // Update the display
                popupText.text = "You have removed a corporate-approved application!";
                popupText.color = Color.red;
                StartCoroutine(ShowWhitelistFeedback());
                Debug.Log("Unfortunately, you have removed a corporate-approved application.");
            }

            GridElementScript.selectedElement = null;
            ClosePopup();
        }
        else
        {
            Debug.LogWarning("No element is selected to remove.");
        }

        
    }

    IEnumerator ShowWhitelistFeedback()
    {
        yield return new WaitForSeconds(1);
        popupText.text = "";
        UpdateAttemptsInfo();

        if (IncorrectGuesses >= MaxTries)
        {
            popupText.text = "Game Over. You've run out of attempts.";
            popupText.color = Color.red;
            
        }
    }
    public string GetAttemptsInfo()
    {
        int attemptsLeft = MaxTries - IncorrectGuesses;
        return "Incorrect Guesses Left: " + attemptsLeft;
    }

    void UpdateAttemptsInfo()
    {
        // Update the text element with the current value of attemptsLeft
        IncorrectGuessesLeft.text = GetAttemptsInfo();
    }
    void Update()
    {
        UpdateAttemptsInfo();
    }
}
