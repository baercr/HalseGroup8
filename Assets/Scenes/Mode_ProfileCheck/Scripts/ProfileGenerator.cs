using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileGenerator : MonoBehaviour
{
    public Image bodyRenderer;
    public Image faceRenderer;
    public Image hairRenderer;
    public Image kitRenderer;

    public Sprite[] bodySprites;
    public Sprite[] faceSprites;
    public Sprite[] hairSprites;
    public Sprite[] kitSprites;

    public Color[] background;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        GenerateRandomProfile();
        
    }

    public void GenerateRandomProfile()
    {
        
            bodyRenderer.sprite = bodySprites[Random.Range(0, bodySprites.Length)];
            faceRenderer.sprite = faceSprites[Random.Range(0, faceSprites.Length)];
            hairRenderer.sprite = hairSprites[Random.Range(0, hairSprites.Length)];
            kitRenderer.sprite = kitSprites[Random.Range(0, kitSprites.Length)];

            cam.backgroundColor = background[Random.Range(0, background.Length)];
    }


}
  