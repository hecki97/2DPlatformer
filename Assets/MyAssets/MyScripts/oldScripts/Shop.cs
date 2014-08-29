using UnityEngine;
using System.Collections;

public class Shop : HealthController {
	
	//||
	
	
	public float coin = 0;
	
	//hecki97
	public float maxHealth = 5;
	public float maxLifePoints = 3;
	private float healthBarLength;
	private float lifePointsBarLength;
	
	private string healthText = "Health";
	private string lifePointsText = "LifePoint";
	private string maxHealthText = "MaxHealth";
	private string moneyText = "coin";
	
	//|| */
	
	public string tag = "Player";
	private SceneFader sceneFader;
	private PlayerController playerController;
	
	bool enterShop = false;
	bool shopMenu = false;
	
	private Color currentColor;
	
	//public Texture2D outsideTexture;
	
	//||
	
	// Use this for initialization
	void Start () {
		//currentHealth = InventoryManager.inventory.GetItems(healthText);
		//lifePoints = InventoryManager.inventory.GetItems(lifePointsText);
		//money = InventoryManager.inventory.GetItems(moneyText);
		
		//hecki97
		//healthBarLength = Screen.width / 2;
		//lifePointsBarLength = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
		//AddjustCurrentHealth(0);
		//AddjustCurrentLifePoints(0);
		
		coin = InventoryManager.inventory.GetItems(moneyText);
		
		//if (currentHealth > 0)
			//initlifePoints = InventoryManager.inventory.GetItems(lifePointsText);
	}
/*	
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
		 initlifePoints += adj;
		
		if(initlifePoints < 1)
			initlifePoints = 0;
		
		if(initlifePoints > 3)
			initlifePoints = maxLifePoints;
		
		if(maxLifePoints < 1)
			maxLifePoints = 1;
		
		lifePointsBarLength = (Screen.width / 4) * (initlifePoints / (float)maxLifePoints);
	}
	
	//|| */
	
	void Awake()
	{	
		sceneFader = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneFader>();	
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	void OnTriggerExit(Collider other)
	{
		//gameObject.transform.parent.renderer.material.mainTexture = outsideTexture;
		enterShop = false;
		shopMenu = false;
	}

	
	void OnTriggerEnter(Collider other)
	{
			if (other.gameObject.CompareTag("Player"))
			enterShop = true;
	}	
	
	void OnGUI()
	{
		/*/||
		
		if (currentHealth <= 0)
			{ 	
				currentColor = Color.clear;
			}
			else
			{
				GUI.Box(new Rect(10, 10, healthBarLength, 20), currentHealth + "/" + maxHealth);
			}

			if (initlifePoints <= 0 || currentHealth <= 0)
			{	
				currentColor = Color.clear;
			}
			else
			{
				GUI.Box(new Rect(10, 40, initlifePointsBarLength, 20), initlifePoints + "/" + maxLifePoints);
				
			}
		
		//|| */
		
		if (enterShop)
		{
			if(GUI.Button(new Rect((Screen.width - 160)/2,450,160,60),"Shop") || Input.GetButtonDown("Fire1"))
			{
				currentColor = Color.clear;
				shopMenu = true;
			}
		}
		else
		{
			currentColor = Color.clear;
		}
	
		if (shopMenu)
		{
			
			//sceneFader.SwitchScene(3);
			
	
			if(GUI.Button(new Rect(720, 10,160,60),"Health"))
			{
				if (currentHealth < 5 && coin >= 2)
				{
					coin -= 2;
					currentHealth += 1;
					InventoryManager.inventory.SetItems(moneyText, coin);
					InventoryManager.inventory.SetItems(healthText,currentHealth);
				}
			 
				if (currentHealth >= 5)
				{
			 		GUI.Label(new Rect((Screen.width - 160)/2,(Screen.height - 60)/2,80,30),"Max health rechead!");	
				}
		
				if (coin  <= 1)
				{
					GUI.Label(new Rect((Screen.width - 160)/2,(Screen.height - 60)/2,80,30),"Not enough money!");	
				}
			
			}
			
			if(GUI.Button(new Rect((Screen.width - 160)/2,(Screen.height - 60)/2,160,60),"SceneShop"))
			{
				sceneFader.SwitchScene(3);
			}
	
		}
		else
		{
			currentColor = Color.clear;
		}
	}
}