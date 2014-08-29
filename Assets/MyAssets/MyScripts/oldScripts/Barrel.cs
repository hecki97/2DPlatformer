using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Barrel : MonoBehaviour {

	//public float speed = 8;
	public List<Vector3> waypointPositions;
	//int currentWaypoint = 0;
	public int currentHealth = 3;
	public float damageEffectPause = 0.2F;
	public string tag = "Player";
	//public int damageValue = 1;
	
	public AudioClip hitSound;
	public AudioClip deathSound;
	
	bool isHit = false;
	//bool lookRight = true;
	SpriteController spriteController;
	//Vector3 moveDirection = Vector3.zero;
	//Vector3 targetPositionDelta;
	
	// Use this for initialization
	void Start () {
	spriteController = GetComponent<SpriteController>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void ApplyDamage(int damage)
	{	
		if(!isHit)
		{	
			isHit = true;
			currentHealth -= damage;
			AudioSource.PlayClipAtPoint(hitSound,transform.position,1);
			
			if (currentHealth <= 0)
			{
				currentHealth = 0;
				AudioSource.PlayClipAtPoint(deathSound,transform.position,1);
				Die();
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
		Destroy(gameObject);	
	}
/*
	void OnTriggerEnter(Collider other)
	{
		if (!isHit)
		{	
			//if (other.gameObject.tag == tag)
			//other.gameObject.SendMessage("ApplyDamage",damageValue,SendMessageOptions.DontRequireReceiver);
		}
	}*/
}
