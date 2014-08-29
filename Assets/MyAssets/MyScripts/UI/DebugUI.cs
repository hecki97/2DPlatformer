using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugUI : MonoBehaviour {

    public string fps;
    public string gameVersion;

    private Text debugText;

    void Awake()
    {
        debugText = GetComponent<Text>();

        UIEventsHandler.OnSceneRestart += this.SceneRestart;
        UIEventsHandler.OnPlayerDeath += this.SceneRestart;
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

	void Update()
    { 
       debugText.text = fps + "\n" + gameVersion;
    }
}
