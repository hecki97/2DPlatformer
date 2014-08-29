using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public string tag = "Player";
	private PlayerController playerController;
	
	void Awake()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	void OnTriggerEnter(Collider other)
	{
			if (other.gameObject.CompareTag("Player"))
			Destroy(gameObject);
	}	
}
