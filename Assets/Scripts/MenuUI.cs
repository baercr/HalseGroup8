using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnButtonStart() 
    {
        SceneManager.LoadScene(3);      // Loads Shift Selection
    }

    public void OnButtonQuit() 
    { 
        Application.Quit ();            // Quits Game, will not quit if running from editor
    }

    public void OnButtonMenu()
    {
        SceneManager.LoadScene(3);
    }

    public void OnButtonMainMenu()
    { 
        SceneManager.LoadScene(0);      // Loads Menu Screen
    }

    public void OnShiftSelect() 
    { 
        SceneManager.LoadScene (4);     // Loads Game Scene
    }

    public void OnButtonRegister() 
    {
        SceneManager.LoadScene(1);      // Opens Register Screen
    }

    public void OnButtonLogin()
    {
        SceneManager.LoadScene(2);      // Opens Login Screen
    }
}
