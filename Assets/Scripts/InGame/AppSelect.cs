using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AppSelect : MonoBehaviour
{
    public Button SceneSwap;

    private void Update()
    {
        SceneSwap.onClick.AddListener(SceneSelect);
    }

    void SceneSelect() 
    {
        SceneManager.LoadScene(0);
    } 
}
