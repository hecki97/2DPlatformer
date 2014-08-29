using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

	public bool isActivated = false;
	public Vector3 offset;

	private Transform player;
	CharacterController characterController;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.anyKey)
			isActivated = false;
	}

	void OnTriggerEnter()
	{
		if (characterController.isGrounded)
			player.transform.parent = transform.parent;
	}

	void OnTriggerExit()
	{
		player.transform.parent = null;
	}
}
