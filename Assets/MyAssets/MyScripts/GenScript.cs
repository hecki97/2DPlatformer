using UnityEngine;
using System.Collections;

public class GenScript : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		int i = Random.Range(1, 9);

		if (i <= 2 || i > 7)
			gameObject.SetActive(false);
		else
			gameObject.SetActive(true);
	}
}
