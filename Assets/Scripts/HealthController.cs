using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {
	
	public float currentHealth;
	public float damageEffectPause = 0.2F;
	public float lifePoints;
	public float deathDelay = 4.5F;
	public float respawnDelay = 3;
	public GameObject deathPrefab;
	
	protected float maxHealth = 100;
	
	public AudioClip deathSound;
	public AudioClip hitSound;
	private AudioSource bgMusic;
	
	private SceneFader sceneFader;	
	//hecki97
	public Vector3 offset;
	public GameObject getDamagePrefab;
	public AudioClip gameOver;
	public float delay = 0.25F;
    private LifePointsUI ui_lifePoints;

	private string healthText = "Health";
	private string lifePointsText = "LifePoint";
    private string maxHealthText = "MaxHealth";
	
	void Awake ()
	{
		sceneFader = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneFader>();
        //bgMusic = GameObject.FindGameObjectWithTag("musicManager").GetComponent<AudioSource>();
	}
	
	// Use this for initialization
	 void Start () {
		currentHealth = InventoryManager.inventory.GetItems(healthText);
		lifePoints = InventoryManager.inventory.GetItems(lifePointsText);
	}
	
	// Update is called once per frame
	void Update () {		

		if(currentHealth < 1)
			currentHealth = 0;
		
		if(currentHealth > maxHealth)
			currentHealth = maxHealth;
		
		if(maxHealth < 1)
			maxHealth = 1;
		
		if (currentHealth > 0)
			lifePoints = InventoryManager.inventory.GetItems(lifePointsText);
	}

	void ApplyDamage(float damage)
	{
		if (currentHealth > 0)
		{	
			currentHealth -= damage;
			AudioSource.PlayClipAtPoint(hitSound,transform.position,1);

			InventoryManager.inventory.SetItems(healthText,currentHealth);
			Destroy(Instantiate(getDamagePrefab,transform.position + offset,Quaternion.identity),1);

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
		//bgMusic.Stop();
        AudioSource.PlayClipAtPoint(deathSound, transform.position, 1);
        AudioListener.pause = true;
		
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
		//bgMusic.Stop();
		AudioSource.PlayClipAtPoint(deathSound,transform.position,1);
		
		//hecki97
		AudioSource.PlayClipAtPoint(gameOver,transform.position,1);
		
		SpawnDeathPrefab();
		yield return new WaitForSeconds(delay);
		//Application.LoadLevel(0);	
		sceneFader.SwitchScene(0);
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
}