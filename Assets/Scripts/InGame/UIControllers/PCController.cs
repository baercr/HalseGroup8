using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PCController : MonoBehaviour
{
    public Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        buttons[0].onClick.AddListener(OnApp0Clicked);
        buttons[1].onClick.AddListener(OnApp1Clicked);
        buttons[2].onClick.AddListener(OnApp2Clicked);
        //buttons[3].onClick.AddListener(OnApp3Clicked);
    }

    private void OnApp0Clicked()
    {
        SceneManager.LoadScene(2);
    }

    private void OnApp1Clicked()
    {
        SceneManager.LoadScene(3);
    }

    private void OnApp2Clicked()
    {
        SceneManager.LoadScene(4);
    }

    /*private void OnApp3Clicked()
    {
        SceneManager.LoadScene();
    }*/
}
