using UnityEngine;
using System.Collections;

public class InventoryManager : MonoBehaviour {

	static public Inventory inventory;
	
	//public bool create = false;
	public float coin = 0;
	
	// hecki97
	public float portal = 0;
	//private string expText = "exp";

	
	public float initHealth = 100;
	public float initLifePoint = 3;
	public bool initValues = false;
	
	private string healthText = "Health";
	private string lifePointsText = "LifePoint";
	private string maxHealthText = "MaxHealth";
		
	void Awake()
	{
		//if (create)
		if (inventory == null)
		{
			inventory = (Inventory)	ScriptableObject.CreateInstance(typeof(Inventory));
			
			//inventory.SetItems("money", coin);
		}
		/*
		else
		{
			inventory.AddItems("money", 2);
			money = inventory.GetItems("money");	
		}
		*/
	
		if (initValues)
		{	
			//Werte initialisieren
			inventory.Clear();
			inventory.SetItems(healthText, initHealth);
			inventory.SetItems(lifePointsText, initLifePoint);
			inventory.SetItems(maxHealthText, initHealth);
			
		}
	}

	protected virtual void Update()
	{
		coin = inventory.GetItems("coin");	
		
		//hecki97
		portal = inventory.GetItems("portal");
		
	}

}
