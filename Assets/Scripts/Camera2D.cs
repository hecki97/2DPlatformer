using UnityEngine;
using System.Collections;

public class Camera2D : MonoBehaviour {
	
	public Transform target;
	public int zOffset;
	public int minimumHeight = 0;
	
	Vector3 position;
	float currentY;
	float orthoSize;
	
	// Use this for initialization
	void Start () {
		orthoSize = camera.orthographicSize;
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
