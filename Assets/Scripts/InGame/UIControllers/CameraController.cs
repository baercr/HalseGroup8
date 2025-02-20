using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Button cameraToggle;
    public Camera cameraMain;
    //public Camera cameraZoom;

    // Start is called before the first frame update
    void Start()
    {
        cameraToggle.onClick.AddListener(ToggleCameraZoom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleCameraZoom() { 
        
    }
}
