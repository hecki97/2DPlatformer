using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerDemo : MonoBehaviour {

	public float speed = 8;
	public List<Transform> waypoints;
	[HideInInspector]
	public List<Vector3> waypointPositions;
	protected int currentWaypoint = 0;
	
	public AudioClip hitSound;
	public AudioClip deathSound;
	
	protected bool isHit = false;
	bool lookRight = true;
	SpriteController spriteController;
	Vector3 moveDirection = Vector3.zero;
	Vector3 targetPositionDelta;
		
	// Use this for initialization
	protected virtual void Start () {
		spriteController = GetComponent<SpriteController>();
		
		foreach (Transform wp in waypoints)
		{
			waypointPositions.Add(wp.position);
		}
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	WaypointWalk();
	Move();
	SetAnimation();
	}

	void WaypointWalk()
	{
		Vector3 targetPosition = waypointPositions[currentWaypoint];
		targetPositionDelta = targetPosition - transform.position;
	
		if (targetPositionDelta.sqrMagnitude <= 1)
		{
			currentWaypoint ++;	
			
			if (currentWaypoint >= waypointPositions.Count)
				currentWaypoint = 0;
		}	
		else
		{
			if (targetPositionDelta.x > 0)
			{
				lookRight = true;
			}
			else
			{
				lookRight = false;
			}
		}
	}
		
	protected virtual void Move()
	{
		transform.Translate(moveDirection * Time.deltaTime, Space.World);
		moveDirection = targetPositionDelta.normalized * speed;
	}

	void SetAnimation()
	{
		if (lookRight)
		{
		spriteController.SetAnimation(SpriteController.AnimationType.goRight);	
		}
		else
		{
		spriteController.SetAnimation(SpriteController.AnimationType.goLeft);
		}
	}
	
}