using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelInfoUI : MonoBehaviour {
	
	public string World;
	public string Level;
    public float levelInfoTimer;

    private Text levelInfoText;
    private UIController uiController;

    void Awake()
    {
        levelInfoText = GetComponent<Text>();
        uiController = GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>();

        UIEventsHandler.OnSceneRestart += this.SceneRestart;
        UIEventsHandler.OnPlayerDeath += this.SceneRestart;
    }

    void Start()
    {
        if (levelInfoTimer > 0)
            levelInfoTimer -= Time.deltaTime;
        else
            this.gameObject.SetActive(false);
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
        levelInfoText.text = World + "\n" + Level;
    }
}
