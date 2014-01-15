using UnityEngine;
using System.Collections;

public class MiniGame_Quasar : MonoBehaviour {

	private Rect butRect;
	private float ctrlWidth = 160;
	private float ctrlHeight = 30;

	public int currentNumber;
	public int currentCoins;
	public int payout;
	public bool isStarted = false;
	public GUIText currentNumberText;

	void Awake()
	{
		butRect = new Rect((Screen.width - ctrlWidth)/2,0,ctrlWidth, ctrlHeight);
	}
	
	// Update is called once per frame
	void Update () {
		currentNumberText.text = currentNumber.ToString();

		if (currentNumber == 15)
		{
			currentNumberText.color = Color.yellow;
			payout = 5;
		}
		else if (currentNumber == 16)
		{
			currentNumberText.color = Color.yellow;
			payout = 10;
		}
		else if (currentNumber == 17)
		{
			currentNumberText.color = Color.yellow;
			payout = 20;
		}
		else if (currentNumber == 18)
		{
			currentNumberText.color = Color.green;
			payout = 30;
		}
		else if (currentNumber == 19)
		{
			currentNumberText.color = Color.green;
			payout = 40;
		}
		else if (currentNumber == 20)
		{
			currentNumberText.color = Color.green;
		}
		else if (currentNumber >= 21)
		{
			currentNumberText.color = Color.red;
			payout = 0;
		}
		else
		{
			currentNumberText.color = Color.white;
			payout = 0;
		}
	}

	void OnGUI()
	{
		GUI.Box(new Rect(5, 160, 120, 20), "Payout " + payout + " credits");
		GUI.Box(new Rect(5, 180, 120, 20),"Credits Won: " + currentCoins);

		currentNumberText.enabled = false;

		butRect.y = (Screen.height - (2*ctrlHeight + 20))/2;
		butRect.x = (Screen.width - (2*ctrlWidth + 20))/2;
		butRect.y += ctrlHeight + 100;
		butRect.x += ctrlWidth - 70;
		if (GUI.Button(butRect, "Quit MiniGame"))
		{
			Application.LoadLevel(0);
		}

		if (isStarted)
		{
			currentNumberText.enabled = true;

			butRect.y = (Screen.height - (2*ctrlHeight + 20))/2;
			butRect.x = (Screen.width - (2*ctrlWidth + 20))/2;
			if (GUI.Button(butRect, "Add 4 - 7"))
			{
				int i = Random.Range(4, 7);
				currentNumber += i;
			}

			butRect.x += ctrlWidth + 20;
			if (GUI.Button(butRect, "Add 1 - 8"))
			{
				int i = Random.Range(1, 8);
				currentNumber += i;
			}



			if (currentNumber >= 15 && currentNumber < 21)
			{
				butRect.x = (Screen.width - (2*ctrlWidth + 20))/2;
				butRect.x += ctrlWidth - 70;
				butRect.y += ctrlHeight + 20;
				if (GUI.Button(butRect, "Payout"))
				{
					currentCoins += payout;
					payout = 0;
					currentNumber = 0;
					isStarted = false;
				}
			}

			if (currentNumber >= 21)
			{
				butRect.x = (Screen.width - (2*ctrlWidth + 20))/2;
				butRect.y = (Screen.height - (2*ctrlHeight + 20))/2;
				butRect.y += ctrlHeight + 60;
				butRect.x += ctrlWidth - 70;
				if (GUI.Button(butRect, "Play Again (20 Credits)"))
				{
					payout = 0;
					currentNumber = 0;
					currentCoins -= 20;
				}
			}
		}
		else
		{
			butRect.y = (Screen.height - (2*ctrlHeight + 20))/2;
			if (GUI.Button(butRect, "Play (20 Credits)"))
			{
				isStarted = true;
				currentCoins -= 20;
			}
		}
	}
}
