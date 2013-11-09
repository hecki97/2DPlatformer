using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaypointWalker : MonoBehaviour {
	
	public float speed = 8;
	public List<Transform> waypoints;
	[HideInInspector]
	public List<Vector3> waypointPositions;
	protected int currentWaypoint = 0;
	public int currentHealth = 3;
	public float damageEffectPause = 0.2F;
	public string tag = "Player";
	public int damageValue = 1;
	public GameObject deathPrefabRight;
	public GameObject deathPrefabLeft;
	
	public AudioClip hitSound;
	public AudioClip deathSound;
	
	//hecki97
	public GUIText damageText;
	public float textDelay = 0.45F;
	
	protected bool isHit = false;
	bool lookRight = true;
	SpriteController spriteController;
	Vector3 moveDirection = Vector3.zero;
	Vector3 targetPositionDelta;
		
	// Use this for initialization
	protected virtual void Start () {
		//hecki97
		damageText.text = "";
		
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

	protected virtual void ApplyDamage(int damage)
	{	
		if(!isHit)
		{	
			isHit = true;
			currentHealth -= damage;
			StartCoroutine(SetDamageText(textDelay));
			AudioSource.PlayClipAtPoint(hitSound,transform.position,1);
			
			if (currentHealth <= 0)
			{
				currentHealth = 0;
				AudioSource.PlayClipAtPoint(deathSound,transform.position,1);
				Die();
				damageText.text = "";
			}
			else
			{
				StartCoroutine(DamageEffect());
			}
	
		}
	}	
		
	IEnumerator DamageEffect()
	{
		renderer.enabled = false;
		yield return new WaitForSeconds(damageEffectPause);
		renderer.enabled = true;
		yield return new WaitForSeconds(damageEffectPause);
		renderer.enabled = false;
		yield return new WaitForSeconds(damageEffectPause);
		renderer.enabled = true;
		yield return new WaitForSeconds(damageEffectPause);
		renderer.enabled = true;
		isHit = false;
	}

	void Die()
	{
		if (lookRight)
		{
			Destroy(Instantiate(deathPrefabRight,transform.position,Quaternion.identity),5);
		}
		else
		{
			Destroy(Instantiate(deathPrefabLeft,transform.position,Quaternion.identity),5);
		}
		
		Destroy(gameObject);	
	}

	void OnTriggerEnter(Collider other)
	{
		if (!isHit)
		{	
			if (other.gameObject.tag == tag)
			other.gameObject.SendMessage("ApplyDamage",damageValue,SendMessageOptions.DontRequireReceiver);
		}
	}

	IEnumerator SetDamageText(float textDelay)
	{
		damageText.text = "+1";
		yield return new WaitForSeconds(textDelay);
		damageText.text = "";
	}
}