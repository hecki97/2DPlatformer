using UnityEngine;
using System.Collections;

public class PlayerHealthBar : MonoBehaviour {

	public float health = 100f;					// The player's health.
	private SpriteRenderer healthBar;			// Reference to the sprite renderer of the health bar.
	private Vector3 healthScale;				// The local scale of the health bar initially (with full health).
	private HealthController playerHealth;		// Reference to the PlayerControl script.
	
	void Awake ()
	{
		// Setting up references.
		playerHealth = GetComponent<HealthController>();
		healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
		healthScale = healthBar.transform.localScale;
	}

	void Update ()
	{
		health = playerHealth.currentHealth;
		UpdateHealthBar();
	}

	public void UpdateHealthBar ()
	{
		healthBar.material.color = Color.Lerp(Color.red, Color.green,health * 0.1f);
		healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.1f, 1, 1);
	}
}