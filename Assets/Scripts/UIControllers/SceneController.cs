using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void OnButtonStart() 
    {
        SceneManager.LoadScene(1);      // Loads Shift Selection
    }

    public void OnButtonQuit() 
    { 
        Application.Quit();            // Quits Game, will not quit if running from editor
    }

    public void OnButtonDesk()
    {
        SceneManager.LoadScene(1);
    }

    public void OnButtonTerminal()
    {
        SceneManager.LoadScene(2);
    }
    public void OnButtonProfiles()
    {
        SceneManager.LoadScene(3);
    }
    public void OnButtonSoftware()
    {
        SceneManager.LoadScene(4);
    }

    public void OnButtonMainMenu()
    { 
        SceneManager.LoadScene(0);      // Loads Menu Screen
    }

    public void OnButtonRegister() 
    {
        SceneManager.LoadScene(1);      // Opens Register Screen
    }

    public void OnButtonLogin()
    {
        //SceneManager.LoadScene();      // Opens Login Screen
    }

    public void OnTryAgainClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
