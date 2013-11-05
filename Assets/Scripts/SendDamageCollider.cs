using UnityEngine;
using System.Collections;

public class SendDamageCollider : MonoBehaviour {
	
	public int damageValue = 1;
	public string tag = "enemy";
	public bool attacking = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (attacking)
		{	
		if (other.gameObject.tag == tag)
			other.gameObject.SendMessage("ApplyDamage",damageValue,SendMessageOptions.DontRequireReceiver);
	
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (attacking)
		{	
		if (other.gameObject.tag == tag)
			other.gameObject.SendMessage("ApplyDamage",damageValue,SendMessageOptions.DontRequireReceiver);
	
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (attacking)
		{	
		if (other.gameObject.tag == tag)
			other.gameObject.SendMessage("ApplyDamage",damageValue,SendMessageOptions.DontRequireReceiver);
	
		}
	}
}