using UnityEngine;
using System.Collections;

public class GUIBars : HealthController {
	
	private float healthBarLength;
	private float lifePointsBarLength;
	private Color currentColor;
	
	
	// Use this for initialization
	void Start () {
	
		//hecki97
		healthBarLength = Screen.width / 2;
		lifePointsBarLength = Screen.width / 2;
	}
	
	
	//hecki97
	public void AddjustCurrentHealth(int adj)
	{
		 currentHealth += adj;

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
	
	protected override void Update()
	{
		base.Update();
		
		//hecki97
		AddjustCurrentHealth(0);
		AddjustCurrentLifePoints(0);
	}
	
	protected override void OnGUI()
	{
		base.OnGUI();
		
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
	}
	
}
