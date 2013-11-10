using UnityEngine;
using System.Collections;

public class LevelName : MonoBehaviour {
	
	public GUIText LevelNameText;
	public GUIText WorldNameText;
	public string levelName = "";
	public string worldName = "";
	public float textDelay = 0.75F;
	
	void Awake()
	{
		StartCoroutine(SetLevelNameText(textDelay));
	}
	
	IEnumerator SetLevelNameText(float textDelay)
	{
		WorldNameText.text = "Welt - " + worldName;
		LevelNameText.text = "Level - " + levelName;
		yield return new WaitForSeconds(textDelay);
		LevelNameText.text = "";
		WorldNameText.text = "";
	}
	
		
}
