using UnityEngine;
using System.Collections;

public class Coin : InventoryManager {
/*
	public float coinBarLength;
	public float maxCoins = 100;
	private Color currentColor;
	private string moneyText = "coin";
	
	//hecki97
	void Start()
	{
		coinBarLength = Screen.width / 2;
		coin = InventoryManager.inventory.GetItems("coin");
	}
	
	//hecki97
	public void AddjustCoinCounter(int adj)
	{
		 coin += adj;
		
		if(coin < 1)
			coin = 0;
		
		if(coin > maxCoins)
			coin = maxCoins;

		
		coinBarLength = (Screen.width / 10);
	}
	
	protected override void Update()
	{
		base.Update();
		
		//hecki97
		AddjustCoinCounter(0);
		
			
	}
	
	 void OnGUI()
	{
		//base.OnGUI();
		
		if (coin <= 0)
		{	
			currentColor = Color.clear;
		}
		else
		{
			GUI.Box(new Rect((Screen.width - 80)/2, 10, coinBarLength, 20), coin + " $");	
		}
	}
	*/
}
