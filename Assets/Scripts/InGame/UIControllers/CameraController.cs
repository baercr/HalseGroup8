using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Camera cam1;             //main camera
    public Camera cam2;             // zoom camera
    public Button buttonZoom;

    // Start is called before the first frame update
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if cam2 enabled -> disables buttonZoom to prevent overlapping button with App
        
        if (cam2.enabled)           
        {
            buttonZoom.enabled = false;
        }

        // else cam1 is enabled to see office and allows player to press button to zoom in

        else
        {
            buttonZoom.onClick.AddListener(ZoomClicked);
        }
                     
        
    }

    void ZoomClicked() {
        //Debug.Log("Zoom button clicked.");
        cam1.enabled = !cam1.enabled;
        cam2.enabled = !cam2.enabled;
    }
}
