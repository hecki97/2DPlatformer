using UnityEngine;
using System.Collections;

public class DamageGUI : MonoBehaviour {

	public Transform target;
	public int zOffset;
	public int minimumHeight = 0;
	
	private HealthController healthController;	
	
	Vector3 position;
	float currentY;
	float orthoSize;
	
	void Awake()
	{
		healthController = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
	}
	
	void DisplayDamage() 
	{
		
	}
	// Update is called once per frame
	void LateUpdate () {
		position = target.position;
		position.z -= zOffset;
		
		currentY = target.position.y;
		
		if (currentY > minimumHeight + orthoSize - 1)
		{
			position.y = currentY - orthoSize + 1;	
		}
		else
		{
			position.y = minimumHeight;
		}
			
		transform.position = position;
	}
}
