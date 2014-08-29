using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour {

	public float timer;

    private Text timerText;

    void Awake()
    {
        UIEventsHandler.OnSceneRestart += this.SceneRestart;
        UIEventsHandler.OnPlayerDeath += this.SceneRestart;
    }

    void Start()
    {
        timerText = GetComponent<Text>();
    }

    void OnDisable()
    {
        UIEventsHandler.OnSceneRestart -= this.SceneRestart;
        UIEventsHandler.OnPlayerDeath -= this.SceneRestart;
    }

    public void SceneRestart()
    {
        this.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		timerText.text = "Timer: " + timer.ToString("0");
	}
}
