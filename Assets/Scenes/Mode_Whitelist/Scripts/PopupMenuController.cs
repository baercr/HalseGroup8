using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class PopupMenuController : MonoBehaviour
{
    // Reference to the popup menu UI object
    public GameObject popupMenu;

    public TextMeshProUGUI popupText;

    public TextMeshProUGUI IncorrectGuessesLeft;

    // Transform of the grid parent containing grid elements
    public Transform gridParent;

    private int IncorrectGuesses = 0;

    private int MaxTries = 5;

    

    

  
   

    // Function to close the popup menu
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

    // Function to remove the selected grid element
    public void RemoveSelectedElement()
    {
        if (GridElementScript.selectedElement != null)
        {
            // Determine if the selected element is active or inactive
            bool isActive = GridElementScript.selectedElement.isActive;

            // Destroy the selected grid element
            Destroy(GridElementScript.selectedElement.gameObject);

            // Display a message based on the state of the removed element
            if (isActive)
            {
                popupText.text = "successfully removed the non-approved software!";
                popupText.color = Color.green;
                StartCoroutine(ShowWhitelistFeedback());
                Debug.Log("You have successfully removed the non-approved software!");
            }
            else
            {
                IncorrectGuesses++;
                UpdateAttemptsInfo();
                popupText.text = "you have removed a corporate-approved application!";
                popupText.color = Color.red;
                StartCoroutine(ShowWhitelistFeedback());
                Debug.Log("Unfortunately, you have removed a corporate-approved application.");
                
            }

            

            // Clear the selected element
            GridElementScript.selectedElement = null;
            // Close the popup menu
            ClosePopup();
        }
        else
        {
            Debug.LogWarning("No element is selected to remove.");
        }
        if(IncorrectGuesses >= MaxTries)
        {
            popupText.text = "Game Over. You've run out of attempts.";
            popupText.color = Color.red;
        }
    }
    IEnumerator ShowWhitelistFeedback()
        {
            yield return new WaitForSeconds(1);
            popupText.text = "";
            
            
        }


    void UpdateAttemptsInfo()
        {
            int attemptsLeft = MaxTries-IncorrectGuesses;
            
            IncorrectGuessesLeft.text = "Incorrect Guesses Left: "+ IncorrectGuesses;
        }
    void Update()
        {
            UpdateAttemptsInfo();
        }

}
