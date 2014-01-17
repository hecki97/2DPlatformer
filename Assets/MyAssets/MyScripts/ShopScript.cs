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

	// Use this for initialization
	void Awake () {
		butRect = new Rect((Screen.width - ctrlWidth)/2,0,ctrlWidth, ctrlHeight);
		sceneFader = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneFader>();
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
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
			butRect.y += 20;
			GUI.Box(butRect, "Current Health: " + currentHealth);
			
			butRect.y += 40;
			GUI.Box(butRect, "Current LifePoints: " + invLifePoints);

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

		}
	}
}
