using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SignScript : MonoBehaviour {

	public string tag = "Player";
    public bool isActivated = false;

    void Update()
    {
        if (isActivated)
        {
            gameObject.GetChild("Canvas").SetActive(true);
        }
        else
            gameObject.GetChild("Canvas").SetActive(false);
    }

	void OnTriggerStay(Collider other) {
		if (other.gameObject.CompareTag(tag))
			isActivated = true;
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag(tag))
			isActivated = false;
    }
}
