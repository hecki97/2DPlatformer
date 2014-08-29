using UnityEngine;
using System.Collections;

public class InventoryCollider : MonoBehaviour {
	
	public string itemName = "coin";
	public float val = 1;
	public string tag = "Player";
	public string id = "";
	public bool oneLife = false;
	
	public AudioClip pickUpSound;
	
	void Awake()
	{
		if(oneLife)
		{
			float val = InventoryManager.inventory.GetItems(id);
			
			if (val > 0)
				Destroy (gameObject);
		}
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if (tag == "" || collider.gameObject.tag == tag)
		{
			AudioSource.PlayClipAtPoint(pickUpSound,transform.position,1);
			InventoryManager.inventory.AddItems(itemName,val);
			Destroy(gameObject);
			
			if (oneLife)
				InventoryManager.inventory.SetItems(id,1);
		}
	}
}