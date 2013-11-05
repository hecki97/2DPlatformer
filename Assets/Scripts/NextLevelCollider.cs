using UnityEngine;
using System.Collections;

public class NextLevelCollider : MonoBehaviour {
	
	public int levelIndex;
	public string tag = "Player";
	private SceneFader sceneFader;
	private PlayerController playerController;
	
	void Awake()
	{
		sceneFader = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneFader>();	
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	void OnTriggerEnter(Collider other)
	{
			if (tag == "" || other.gameObject.CompareTag(tag))
			{
				NextLevel();
			}
	}
	
	void NextLevel()
	{
		//Application.LoadLevel(levelIndex);	
		playerController.sceneSwitch = true;
		sceneFader.SwitchScene(levelIndex);
	}
			
}
