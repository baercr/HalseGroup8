using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileGenerator : MonoBehaviour
{
    public Sprite[] bodySprites;
    public Sprite[] faceSprites;
    public Sprite[] hairSprites;
    public Sprite[] kitSprites;

    public SpriteRenderer bodyRenderer;
    public SpriteRenderer faceRenderer;
    public SpriteRenderer hairRenderer;
    public SpriteRenderer kitRenderer;


    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomProfile();
        
    }

    void GenerateRandomProfile()
    {
        if (bodySprites.Length > 0 && faceSprites.Length > 0 && hairSprites.Length > 0 && kitSprites.Length > 0)
        {
            bodyRenderer.sprite = bodySprites[Random.Range(0, bodySprites.Length)];
            faceRenderer.sprite = faceSprites[Random.Range(0, faceSprites.Length)];
            hairRenderer.sprite = hairSprites[Random.Range(0, hairSprites.Length)];
            kitRenderer.sprite = kitSprites[Random.Range(0, kitSprites.Length)];

            Debug.Log("Profile generated successfully.");
        }
        else
        {
            Debug.LogError("One or more sprite arrays are empty.");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
