using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSample : MonoBehaviour
{
	public Image cbody;
	public Image cface;
	public Image chair;
	public Image ckit;

	public Sprite[] body;
	public Sprite[] face;
	public Sprite[] hair;
	public Sprite[] kit;

	public Sprite defaultBody;
	public Sprite defaultFace;
	public Sprite defaultHair;
	public Sprite defaultKit;

	//public Color[] background;
	private Camera cam;


	// Use this for initialization
	void Start()
	{
		cam = GameObject.Find("Main Camera").GetComponent<Camera>();
		RandomizeCharacter();
	}

	public void RandomizeCharacter()
	{
		//cbody.sprite = body[0];

		if (body.Length > 0)
		{
			cbody.sprite = body[Random.Range(0, body.Length)];
		}
		else
		{
			cbody.sprite = defaultBody;
			Debug.LogWarning("Using default body");
		}

		if (face.Length > 0)
		{
			cface.sprite = face[Random.Range(0, face.Length)];
		}
		else
		{
			cface.sprite = defaultFace;
			Debug.LogWarning("Using default face");
		}

		if (hair.Length > 0)
		{
			chair.sprite = hair[Random.Range(0, hair.Length)];

		}
		else
		{
			chair.sprite = defaultHair;
			Debug.LogWarning("Using default hair");
		}

		if (kit.Length > 0)
		{
			ckit.sprite = kit[Random.Range(0, kit.Length)];

		}
		else
		{
			ckit.sprite = defaultKit;
			Debug.LogWarning("Using default kit");
		}

		EnsureComponentAssigned(cbody, defaultBody);
		EnsureComponentAssigned(cface, defaultFace);
		EnsureComponentAssigned(chair, defaultHair);
		EnsureComponentAssigned(ckit, defaultKit);

		//cam.backgroundColor = background[Random.Range(0,background.Length)];
	}

	private void EnsureComponentAssigned(Image component, Sprite defaultSprite)
	{
		if(component.sprite == null)
		{
			component.sprite = defaultSprite;
		}
	}
}

