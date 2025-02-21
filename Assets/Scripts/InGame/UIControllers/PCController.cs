using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PCController : MonoBehaviour
{
    public Button[] button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        button[0].onClick.AddListener(OnApp0Clicked);
        button[1].onClick.AddListener(OnApp1Clicked);
        button[2].onClick.AddListener(OnApp2Clicked);
        //button[3].onClick.AddListener(OnApp3Clicked);
    }

    public void OnApp0Clicked()
    {
        SceneManager.LoadScene(2);
    }

    public void OnApp1Clicked()
    {
        SceneManager.LoadScene(3);
    }

    public void OnApp2Clicked()
    {
        SceneManager.LoadScene(4);
    }

    /*public void OnApp3Clicked()
    {
        SceneManager.LoadScene();
    }*/
}
