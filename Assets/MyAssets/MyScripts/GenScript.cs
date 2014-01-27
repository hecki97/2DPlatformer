using UnityEngine;
using System.Collections;

public class GenScript : MonoBehaviour {

	private CollectItem collectItem;

	// Use this for initialization
	void Awake () {
		collectItem = GameObject.FindGameObjectWithTag("Plant").GetComponent<CollectItem>();

		int i = Random.Range(1, 9);
		if (i <= 2)
			gameObject.SetActive(false);
		if (i > 2 && i <= 7)
			gameObject.SetActive(true);
		if (i > 7)
			gameObject.SetActive(false);
	}
}
