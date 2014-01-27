using UnityEngine;
using System.Collections;

public class ShopScript : MonoBehaviour {

	private string healthText = "Health";
	private string lifePointsText = "LifePoint";
	private string maxHealthText = "MaxHealth";
	private string moneyText = "coin";

	public float invCurrentHealth = 5;
	public float invLifePoints = 3;
	public float invMoney = 0;
	public float currentHealth;

	private Rect butRect;
	private float ctrlWidth = 160;
	private float ctrlHeight = 30;
	public bool isActivated = false;
	private HealthController playerHealth;
	private SceneFader sceneFader;	
	public float maxHealth = 5;
	public float maxLifePoints = 3;
	public bool isOpen = false;
	public bool isPressed = false;
	public string tag = "Player";
	private Item item;
	private PlayerController timer;

	// Use this for initialization
	void Awake () {
		butRect = new Rect((Screen.width - ctrlWidth)/2,0,ctrlWidth, ctrlHeight);
		sceneFader = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneFader>();
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
		timer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		item = GameObject.FindGameObjectWithTag("GameController").GetComponent<Item>();
	}

	void Start () {
		invCurrentHealth = InventoryManager.inventory.GetItems(healthText);
		invLifePoints = InventoryManager.inventory.GetItems(lifePointsText);
		invMoney = InventoryManager.inventory.GetItems(moneyText);
	}

	void OnTriggerEnter(Collider other)
	{
		if (tag == "" || other.gameObject.CompareTag(tag))
		{
			Debug.Log("Activated");
			isActivated = true;
			isPressed = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (tag == "" || other.gameObject.CompareTag(tag))
		{
			Debug.Log("Deactivated");
			isActivated = false;
			isPressed = false;
		}
	}

	void OnGUI()
	{
		butRect.y = (Screen.height - (2*ctrlHeight + 20))/2;

		if (isActivated && isPressed)
			if (GUI.Button(butRect, "Press E!"))
			{
				isOpen = true;
				isPressed = false;
			}

		if (isActivated && isOpen)
		{
			GUI.Box(new Rect(Screen.width / 4, 160, 150, 20), "Current Health: " + currentHealth);
			GUI.Box(new Rect(Screen.width / 4, 185, 150, 20), "Current LifePoints: " + invLifePoints);
			GUI.Box(new Rect(Screen.width / 4, 210, 150, 20), "Current Money: " + invMoney);

			butRect.y -= 50;
			if (GUI.Button(butRect, "Add Health +1"))
			{
				if (invMoney >= 2 && currentHealth <= 10)
				{
					invMoney -= 2;
					InventoryManager.inventory.SetItems(moneyText, invMoney);
					currentHealth++;
					InventoryManager.inventory.SetItems(healthText, currentHealth);
					playerHealth.currentHealth = InventoryManager.inventory.GetItems(healthText);
				}

			}

			butRect.y += 35;
			if (GUI.Button(butRect, "Add Health +5"))
			{
				if (invMoney >= 10 && currentHealth <= 5)
				{
					invMoney -= 10;
					InventoryManager.inventory.SetItems(moneyText, invMoney);
					currentHealth += 5;
					InventoryManager.inventory.SetItems(healthText, currentHealth);
					playerHealth.currentHealth = InventoryManager.inventory.GetItems(healthText);
				}
			}

			butRect.y += 50;
			if (GUI.Button(butRect, "Sell Plants -1"))
			{
				if (item.currentPlants >= 1)
				{
					item.currentPlants--;
					int i = Random.Range(1, 3);
					invMoney += i;
					InventoryManager.inventory.SetItems(moneyText, invMoney);
					invMoney = InventoryManager.inventory.GetItems(moneyText);
				}
			}

			butRect.y += 35;
			if (GUI.Button(butRect, "Sell Sticks -1"))
			{
				if (item.currentSticks >= 1)
				{
					item.currentSticks--;
					int i = Random.Range(1, 3);
					invMoney += i;
					InventoryManager.inventory.SetItems(moneyText, invMoney);
					invMoney = InventoryManager.inventory.GetItems(moneyText);
				}
			}

			butRect.y += 50;
			if (GUI.Button(butRect, "Add Time +15"))
			{
				if (invMoney >= 2)
				{
					invMoney -= 2;
					InventoryManager.inventory.SetItems(moneyText, invMoney);
					timer.timer += 15;

				}
			}

			butRect.y += 60;
			if (GUI.Button(butRect, "Exit Shop"))
			{
				isActivated = false;
				isOpen = false;
				Time.timeScale = 1;
			}
		}
		

	}

	// Update is called once per frame
	void Update () {
		if (isActivated && isOpen)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;

		if (isActivated && Input.GetKeyDown(KeyCode.E))
		{
			isOpen = true;
			isPressed = false;
		}

		if (isActivated)
		{
				InventoryManager.inventory.SetItems(healthText, playerHealth.currentHealth);
				currentHealth = InventoryManager.inventory.GetItems(healthText);
				invMoney = InventoryManager.inventory.GetItems(moneyText);

		}
	}
}
