using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnButtonStart() 
    {
        SceneManager.LoadScene(1);
    }

    public void OnButtonQuit() 
    { 
        Application.Quit ();
    }

    public void OnButtonMainMenu()
    { 
        SceneManager.LoadScene(0); 
    }
}
