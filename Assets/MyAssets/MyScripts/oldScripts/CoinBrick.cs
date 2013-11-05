using UnityEngine;
using System.Collections;

public class CoinBrick : MonoBehaviour {
	
	public float money;
	private string moneyText = "coin";
	public AudioClip pickupCoin;
	
	public string tag = "Player";
	private PlayerController playerController;
	
	void Start () {
		money = InventoryManager.inventory.GetItems(moneyText);
	}
	
	void Awake()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint(pickupCoin,transform.position,1);
			money += 1;
			InventoryManager.inventory.SetItems(moneyText, money);
		}
	}	
}
