using UnityEngine;
using System.Collections;

public class CollectItem : Item {
	public bool plants = true;
	public bool sticks = false;

	private Item item;
	public bool isActivated = false;
	public string tag = "Player";
	public AudioClip itemAquired;
	private Rect butRect;
	private float ctrlWidth = 160;
	private float ctrlHeight = 30;
	public bool isCollecting = false;
	public float delay = 2F;
	public float seconds;
	private string restTime;


	void Awake()
	{
		butRect = new Rect((Screen.width - ctrlWidth)/2,0,ctrlWidth, ctrlHeight);
		item = GameObject.FindGameObjectWithTag("GameController").GetComponent<Item>();
	}

	void OnGUI()
	{
		butRect.y = (Screen.height - (2*ctrlHeight + 20))/2;

		//GUI
		//GUI.Box(new Rect(5, 160, 120, 20), "Plants : x" + item.currentPlants);
		//GUI.Box(new Rect(5, 180, 120, 20), "WoodPlanks : x" + item.currentWoodPlanks);
		//GUI.Box(new Rect(5, 200, 120, 20), "Sticks : x" + item.currentSticks);

		if (isActivated)
		{
			//GUI.Box(butRect, "Press E");
			butRect.y += ctrlHeight + 150;
			if (GUI.Button(butRect, "Press E"))
			{
				isCollecting = true;
				StartCoroutine(collectItem(delay));

			}
		}
		
		if (isCollecting && isActivated)
		{
			restTime = seconds.ToString("0.0");
			butRect.y += ctrlHeight + 25;
			GUI.Box(butRect, restTime + "/2 s");
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (tag == "" || other.gameObject.CompareTag(tag))
		{
			isActivated = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (tag == "" || other.gameObject.CompareTag(tag))
		{
			isActivated = false;
			isCollecting = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (isActivated && Input.GetKeyDown(KeyCode.E))
			{
				isCollecting = true;
				StartCoroutine(collectItem(delay));
			}

		if (isCollecting)
		{
			seconds += Time.deltaTime;
		}
		else
			seconds = 0;
	}

	IEnumerator collectItem(float delay)
	{
			yield return new WaitForSeconds(delay);

			if (isCollecting && isActivated)
			{
				AudioSource.PlayClipAtPoint(itemAquired, transform.position, 1);
				
				if (plants)
					item.currentPlants++;
				else
					item.currentSticks++;
				Destroy(gameObject);
				isCollecting = false;
			}
	}


}
