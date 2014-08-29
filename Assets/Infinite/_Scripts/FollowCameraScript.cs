using UnityEngine;
using System.Collections;

public class FollowCameraScript : MonoBehaviour {

    public Vector3 offset;

    private Camera camera;

	// Use this for initialization
	void Start () {
	    camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 camPos = new Vector3(camera.transform.position.x, 0 , 0);
        transform.position = camPos + offset;
	}
}
