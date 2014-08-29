using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthPointsUI : MonoBehaviour {

    public float healthPoints;
    public float maxHealthPoints;

    private Graphic image;
    private Text healthPointsText;
    private Text maxHealthPointsText;

    void Awake()
    {
        image = GetComponent<Graphic>();
        healthPointsText = this.gameObject.GetChild("UI_HealthPointsText").GetComponent<Text>();
        maxHealthPointsText = this.gameObject.GetChild("UI_MaxHealthPointsText").GetComponent<Text>();

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

    // Update is called once per frame
    void Update()
    {
        healthPointsText.text = healthPoints.ToString("0");
        maxHealthPointsText.text = "|" + maxHealthPoints.ToString("0");
    }
}
