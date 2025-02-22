using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using Unity.VisualScripting;
>>>>>>> 525377670cc9fec1824008e402b2499ed59462a4
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
<<<<<<< HEAD
    public Button cameraToggle;
    public Camera cameraMain;
    //public Camera cameraZoom;
=======
    public Camera cam1;
    public Camera cam2;
    public Button buttonZoom;
>>>>>>> 525377670cc9fec1824008e402b2499ed59462a4

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        cameraToggle.onClick.AddListener(ToggleCameraZoom);
=======
        cam1.enabled = true;
        cam2.enabled = false;
>>>>>>> 525377670cc9fec1824008e402b2499ed59462a4
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        
    }

    public void ToggleCameraZoom() { 
        
=======
        buttonZoom.onClick.AddListener(ZoomClicked); 
    }

    void ZoomClicked() {
        //Debug.Log("Zoom button clicked.");
        cam1.enabled = !cam1.enabled;
        cam2.enabled = !cam2.enabled;
>>>>>>> 525377670cc9fec1824008e402b2499ed59462a4
    }
}
