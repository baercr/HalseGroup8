using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnButtonStart() 
    {
        SceneManager.LoadScene(1);      // Loads Shift Selection
    }

    public void OnButtonQuit() 
    { 
        Application.Quit ();            // Quits Game, will not quit if running from editor
    }

    public void OnButtonMainMenu()
    { 
        SceneManager.LoadScene(0);      // Loads Menu Screen
    }

    public void OnShiftSelect() 
    { 
        SceneManager.LoadScene (2);     // Loads Game Scene
    }
}
