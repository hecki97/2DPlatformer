using UnityEngine;
using System.Collections;

public class VolumeMenu : MonoBehaviour {

	VolumeMenu script;
	float volume = 1;
	public bool isOpen = false;
	public float vSliderValue = 0.0F;
	private Color currentColor;

	private Rect butRect;
	private float ctrlWidth = 160;
	private float ctrlHeight = 30;

	void Awake()
	{
		butRect = new Rect((Screen.width - ctrlWidth)/2,0,ctrlWidth, ctrlHeight);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.V))
		{
			if (!isOpen)
				isOpen = true;
			else
				isOpen = false;
		}	
	}

	void OnGui()
	{
		currentColor = Color.clear;

		if (isOpen)
		{
			butRect.y = (Screen.height - (2*ctrlHeight + 20))/2;
			Debug.Log("isOpen");
			butRect.y = GUILayout.HorizontalSlider(butRect.y, 10.0F, 0.0F);
		}
			
	}
}
