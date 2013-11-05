using UnityEngine;
using System.Collections;

public class ShopMenu : MonoBehaviour {

	public float currentHealth = 5;
	public float lifePoints = 3;
	public float money = 0;
	
	private SceneFader sceneFader;	
	//hecki97
	public float maxHealth = 5;
	public float maxLifePoints = 3;
	private float healthBarLength;
	private float lifePointsBarLength;
	private Color currentColor;
	
	private string healthText = "Health";
	private string lifePointsText = "LifePoint";
	private string maxHealthText = "MaxHealth";
	private string moneyText = "coin";
	
	void Awake ()
	{	
		sceneFader = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneFader>();
	}
	
	// Use this for initialization
	void Start () {
		currentHealth = InventoryManager.inventory.GetItems(healthText);
		lifePoints = InventoryManager.inventory.GetItems(lifePointsText);
		
		money = InventoryManager.inventory.GetItems(moneyText);
		
		//hecki97
		healthBarLength = Screen.width / 2;
		lifePointsBarLength = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
		//hecki97
		AddjustCurrentHealth(0);
		AddjustCurrentLifePoints(0);
		
		
		
		if (currentHealth > 0)
			lifePoints = InventoryManager.inventory.GetItems(lifePointsText);
	}
	
	void OnGUI()
	{
		//hecki97
		if (currentHealth <= 0)
		{ 	
			currentColor = Color.clear;
		}
		else
		{
			GUI.Box(new Rect(10, 10, healthBarLength, 20), currentHealth + "/" + maxHealth);
		}
		//hecki97
		if (lifePoints <= 0 || currentHealth <= 0)
		{	
			currentColor = Color.clear;
		}
		else
		{
			GUI.Box(new Rect(10, 40, lifePointsBarLength, 20), lifePoints + "/" + maxLifePoints);
		}
	
		if(GUI.Button(new Rect(720, 10,160,60),"Health"))
		{
			if (currentHealth < 5 && money >= 2)
			{
				money -= 2;
				currentHealth += 1;
				InventoryManager.inventory.SetItems(moneyText, money);
			}
			 
			if (currentHealth >= 5)
			{
			 	GUI.Label(new Rect((Screen.width - 80)/2,(Screen.height - 30)/2,80,30),"Max health rechead!");	
			}
		
			if (money  <= 1)
			{
				GUI.Label(new Rect((Screen.width - 80)/2,(Screen.height - 30)/2,80,30),"Not enough money!");	
			}
		
		}
	
		if(GUI.Button(new Rect(720, 250,160,60),"Back to Game"))
			{
				InventoryManager.inventory.SetItems(healthText,currentHealth);
				//Application.LoadLevel(1);
				sceneFader.SwitchScene(1);
			}
	}
	
	//hecki97
	public void AddjustCurrentHealth(int adj)
	{
		 currentHealth += adj;
		
		if(currentHealth < 1)
			currentHealth = 0;
		
		if(currentHealth > maxHealth)
			currentHealth = maxHealth;
		
		if(maxHealth < 1)
			maxHealth = 1;
		
		healthBarLength = (Screen.width / 4) * (currentHealth / (float)maxHealth);
	}
	
	//hecki97
	public void AddjustCurrentLifePoints(int adj)
	{
		 lifePoints += adj;
		
		if(lifePoints < 1)
			lifePoints = 0;
		
		if(lifePoints > 3)
			lifePoints = maxLifePoints;
		
		if(maxLifePoints < 1)
			maxLifePoints = 1;
		
		lifePointsBarLength = (Screen.width / 4) * (lifePoints / (float)maxLifePoints);
	}
}