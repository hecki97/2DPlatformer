using UnityEngine;
using System.Collections;

public class EnableByDestroy : MonoBehaviour {
	
	public GameObject target;
	
	void OnDestroy()
	{
		target.SetActive(true);
	}
}
