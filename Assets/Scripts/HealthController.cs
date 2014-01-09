using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {
	
	public float currentHealth = 100;
	public float damageEffectPause = 0.2F;
	public float lifePoints = 3;
	//public float deathDelay = 4;
	public float deathDelay = 4.5F;
	public float respawnDelay = 3;
	public GameObject deathPrefab;
	
	protected float maxHealth = 100;
	protected float maxLifePoints = 3;
	
	public AudioClip deathSound;
	public AudioClip hitSound;
	private AudioSource bgMusic;
	
	private SceneFader sceneFader;	
	//hecki97
	public Vector3 offset;
	public GameObject getDamagePrefab;
	private GameOverFader gameOverFader;
	public AudioClip gameOver;
	public Texture2D heart;
	public Texture2D lifePoint;
	public GUIText heartText;
	public GUIText lifePointText;
	public GUIText gameOverText;
	private float heartCount;
	private float lifePointCount;
	public float gravity = 5;
	public float jumpPower = 10;
	Vector3 moveDirection = Vector3.zero;
	public float delay = 0.25F;
	public float hurtForce = 10f;
	public GUITexture getHurt;
	public float hurtDelay = 0.015F;

	private string healthText = "Health";
	private string lifePointsText = "LifePoint";
	private string maxHealthText = "MaxHealth";
	
	void Awake ()
	{
		//hecki97
		gameOverFader = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameOverFader>();

		sceneFader = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneFader>();
		bgMusic = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();	
	}
	
	// Use this for initialization
	protected virtual void Start () {
		//hecki97
		SetCountText();
		gameOverText.text = "";
		
		currentHealth = InventoryManager.inventory.GetItems(healthText);
		lifePoints = InventoryManager.inventory.GetItems(lifePointsText);
	}
	
	// Update is called once per frame
	protected virtual void Update () {		


		if(currentHealth < 1)
			currentHealth = 0;
		
		if(currentHealth > maxHealth)
			currentHealth = maxHealth;
		
		if(maxHealth < 1)
			maxHealth = 1;
		
		if (currentHealth > 0)
			lifePoints = InventoryManager.inventory.GetItems(lifePointsText);
	
		heartCount = currentHealth;
		lifePointCount = lifePoints;
		SetCountText();
	}

	void ApplyDamage(float damage)
	{
		if (currentHealth > 0)
		{	
			currentHealth -= damage;
			AudioSource.PlayClipAtPoint(hitSound,transform.position,1);
			
			//hecki97
			transform.position = transform.position + Vector3.up * 0.75F;
			InventoryManager.inventory.SetItems(healthText,currentHealth);
			Destroy(Instantiate(getDamagePrefab,transform.position + offset,Quaternion.identity),1);
			StartCoroutine(GetHurt(hurtDelay));

			if (currentHealth < 0)
				currentHealth = 0;
	
			if (currentHealth == 0)
			{
				lifePoints -= 1;
				InventoryManager.inventory.SetItems(lifePointsText,lifePoints);
				
				if (lifePoints <= 0)
				{
					//GameOver?
					StartCoroutine(GameOver(deathDelay));
				}
				else
				{
					StartCoroutine(RestartScene(respawnDelay));
				}
			}
			else
			{
					StartCoroutine(DamageEffect());
					InventoryManager.inventory.SetItems(healthText,currentHealth);
			}
		
		}
	}	
		
	IEnumerator RestartScene(float delay)
	{
		bgMusic.Stop();
		AudioSource.PlayClipAtPoint(deathSound,transform.position,1);
		
		SpawnDeathPrefab();
		yield return new WaitForSeconds(delay);
		float temp;
		temp = InventoryManager.inventory.GetItems(maxHealthText);
		InventoryManager.inventory.SetItems(healthText,temp);
		InventoryManager.inventory.SetItems(lifePointsText,lifePoints);
		//hecki97
		//InventoryManager.inventory.SetItems("coin",0);
		
		//Application.LoadLevel(Application.loadedLevel);
		sceneFader.SwitchScene(Application.loadedLevel);
		InventoryManager.inventory.GetItems(lifePointsText);
	}
	
	IEnumerator GameOver(float delay)
	{
		bgMusic.Stop();
		AudioSource.PlayClipAtPoint(deathSound,transform.position,1);
		
		//hecki97
		AudioSource.PlayClipAtPoint(gameOver,transform.position,1);
		
		SpawnDeathPrefab();
		yield return new WaitForSeconds(delay);
		//Application.LoadLevel(0);	
		//sceneFader.SwitchScene(0);
	
		//hecki97
		gameOverFader.SwitchScene(0);
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
	}
	
	void SpawnDeathPrefab()
	{
		if (deathPrefab != null)
		{
			GameObject go = (GameObject) Instantiate (deathPrefab,transform.position,Quaternion.identity);
			go.rigidbody.AddForce (Vector3.up * 100);
		}
	}
	
	protected virtual void OnGUI()
	{

		if (currentHealth <= 0 && lifePoints <= 0)
			//GUI.Label(new Rect((Screen.width - 80)/2,(Screen.height - 30)/2,80,30),"GAME OVER");
			gameOverText.text = "GAME OVER!";
	}
	
	void SetCountText()
	{
		heartText.text = heartCount.ToString();	
		lifePointText.text = lifePointCount.ToString();	
	}

	IEnumerator GetHurt(float hurtDelay)
	{
		getHurt.enabled = true;
		yield return new WaitForSeconds(hurtDelay);
		getHurt.enabled = false;
	}
}