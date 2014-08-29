using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour {

	private SceneFader sceneFader;
	public bool destroyAll = false;

	void Awake()
	{
		sceneFader = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneFader>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			//Application.LoadLevel(Application.loadedLevel);
			other.gameObject.SetActive(false);
			sceneFader.SwitchScene(Application.loadedLevel);
			return;
		}

		if (destroyAll)
		{
			if (other.gameObject.transform.parent)
			{
				Destroy(other.gameObject.transform.parent.gameObject);
			}
			else
			{
				Destroy(other.gameObject);
			}
		}
	}
}
