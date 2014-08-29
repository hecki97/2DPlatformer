using UnityEngine;
using System.Collections;

public class SpawnPlayerScript : MonoBehaviour {

    public GameObject player;
    public ParticleSystem spawnSparkles;
    public bool initValues = false;
    public float countdown = 1.5f;

	// Use this for initialization
	void Awake () {
	    if (initValues)
        {
            Instantiate(player, transform.position, Quaternion.identity);
            spawnSparkles.gameObject.SetActive(true);
            PlayerPrefs.SetString("Checkpoint", "false");
            StartCoroutine(StartCountdown());
        }
        
        if (!initValues && PlayerPrefs.GetString("Checkpoint") == "true")
        {

        }
	}
	
    void OnTriggerEnter()
    {
        if(!initValues)
        {
            PlayerPrefs.SetString("Checkpoint", "true");
        }
    }

    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(countdown);
        Destroy(gameObject);
    }
}
