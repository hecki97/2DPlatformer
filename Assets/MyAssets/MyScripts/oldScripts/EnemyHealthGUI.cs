using UnityEngine;
using System.Collections;

public class EnemyHealthGUI : WaypointWalker {
	
	
	public Transform target;
	public int zOffset;
	public int minimumHeight = 0;
	
	Vector3 position;
	float currentY;
	float orthoSize;
	
	//hecki97
	public float maxHealth = 3;
	private Color currentColor;
	public float healthBarLength;
	
	// Use this for initialization
	protected override void Start () {
	
		//hecki97
		healthBarLength = Screen.width / 2;
	}
	
	//hecki97
	public void AddjustCurrentHealth(int adj)
	{
		 currentHealth += adj;
		
		if(currentHealth < 1)
			currentHealth = 0;
		
		if(maxHealth < 1)
			maxHealth = 1;
		
		healthBarLength = (Screen.width / 4) * (currentHealth / (float)maxHealth);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		position = target.position;
		position.z -= zOffset;
		
		currentY = target.position.y;
		
		if (currentY > minimumHeight + orthoSize - 1)
		{
			position.y = currentY - orthoSize + 1;	
		}
		else
		{
			position.y = minimumHeight;
		}
			
		transform.position = position;
	}

	//hecki97
	void OnGUI()
	{
		if (currentHealth <= 0)
		{ 	
			currentColor = Color.clear;
		}
		else
		{
			GUI.Box(new Rect(minimumHeight, 10, healthBarLength, 20), currentHealth + "/" + maxHealth);
		}
	}

	protected override void Update()
	{
		base.Update();
		
		//hecki97
		AddjustCurrentHealth(0);
	}
	
}
