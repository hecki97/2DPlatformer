using UnityEngine;
using System.Collections;

public class Camera2D : MonoBehaviour {

	//hecki97
	public float smoothDampTime = 0.2f;
	private Vector3 _smoothDampVelocity;

	//public Transform target;
	public int zOffset;
	public int minimumHeight = 0;

    private PlayerController playerController;

	Vector3 position;
	float currentY;
	float orthoSize;

	// Use this for initialization
	void Start () {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		orthoSize = camera.orthographicSize;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//position = target.position;
        position = playerController.transform.position;
		position.z -= zOffset;
		
		//currentY = target.position.y;
        currentY = playerController.transform.position.y;

		if (currentY > minimumHeight + orthoSize - 1)
		{
			position.y = currentY - orthoSize + 1;	
		}
		else
		{
			position.y = minimumHeight;
		}
			
		//transform.position = position;
		transform.position = Vector3.SmoothDamp(transform.position, position, ref _smoothDampVelocity, smoothDampTime);
	}
}
