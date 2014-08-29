using UnityEngine;
using System.Collections;

public class jumpPadScript : MonoBehaviour {
	
	public float jumpPower = 5F;
	public float cooldown = 0.5F;
	public bool isActive = true;
	
	CharacterController characterController;
	Vector3 moveDirection = Vector3.zero;
	private Transform player;
	
	// Use this for initialization
	void Awake () {
		characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void OnTriggerEnter(Collider other) {
		if (isActive)
		{
			player.transform.position += Vector3.up * jumpPower;
			isActive = false;
			StartCoroutine(Cooldown());
		}
	}
	
	IEnumerator Cooldown()
	{
		yield return new WaitForSeconds(cooldown);
		isActive = true;
	}
}
