using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TerminalManager : MonoBehaviour
{
    public GameObject directoryLine;
    public GameObject responseLine;

    public TMP_InputField terminalInput;
    public GameObject userInputLine;
    public ScrollRect sr;
    public GameObject msgList;

    private void OnGUI()
    {
        if(terminalInput.isFocused && terminalInput.text != "" && Input.GetKeyDown(KeyCode.Return)) 
        { 
            // Store user text
            string userInput = terminalInput.text;

            // Clear input field
            ClearInputField();

            // Instatitate a gameobject with a directory prefix
            AddDirectoryLine(userInput);

            // Move user input line to bottom
            userInputLine.transform.SetAsLastSibling();

            // Refocus input field
            terminalInput.ActivateInputField();
            terminalInput.Select();
        }
    }
    
    void ClearInputField()
    {
        terminalInput.text = "";
    }

    void AddDirectoryLine(string userInput)
    {
        // Resizes command line container, controls ScrollRect
        Vector2 msgListSize = msgList.GetComponent<RectTransform>().sizeDelta;
        msgList.GetComponent<RectTransform>().sizeDelta = new Vector2(msgListSize.x, msgListSize.y + 35.0f);

        // Instantiate directory line
        GameObject msg = Instantiate(directoryLine, msgList.transform);

        // Set its child index
        msg.transform.SetSiblingIndex(msgList.transform.childCount - 1);

        // Set the text of this new gameobject
        msg.GetComponentsInChildren<TMP_Text>()[1].text = userInput;
    }
}
