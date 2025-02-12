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
        bodyRenderer.sprite = bodySprites[Random.Range(0, bodySprites.Length)];
        faceRenderer.sprite = faceSprites[Random.Range(0, faceSprites.Length)];
        hairRenderer.sprite = hairSprites[Random.Range(0, hairSprites.Length)];
        kitRenderer.sprite = kitSprites[Random.Range(0, kitSprites.Length)];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
