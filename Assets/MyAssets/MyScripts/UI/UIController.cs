using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public float timer;
    public float levelInfoTimer;
    public string World;
    public string Level;

    public TextAsset gameVersionText;
    public float updateInterval = 0.5F;

    private float fps;
    private string format;
    private float accum = 0; // FPS accumulated over the interval
    private int frames = 0; // Frames drawn over the interval
    private float timeleft; // Left time for current interval

    private HealthController healthController;
    private SceneFader sceneFader;
    private HealthPointsUI ui_healthPoints;
    private TimerUI ui_timerText;
    private LevelInfoUI ui_levelInfo;
    private DebugUI ui_debug;

	// Use this for initialization
	void Start () {
        timeleft = updateInterval;  
        
        sceneFader = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneFader>();
        healthController = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();

        ui_timerText = GameObject.Find("UI_Canvas/UI_TimerText").GetComponent<TimerUI>();
        ui_levelInfo = GameObject.Find("UI_Canvas/UI_LevelInfoText").GetComponent<LevelInfoUI>();
        
        ui_healthPoints = GameObject.Find("UI_Canvas/UI_HealthPoints").GetComponent<HealthPointsUI>();
        ui_debug = GameObject.Find("UI_Canvas/UI_Debug").GetComponent<DebugUI>();
	}
	
	// Update is called once per frame
    void Update()
    {
        ui_debug.gameVersion = gameVersionText.text;
        
        SetValues();
        Timer();
        CalculateFps();
    }

    void SetValues()
    {
        ui_healthPoints.healthPoints = healthController.currentHealth;
        ui_healthPoints.maxHealthPoints = 10;
        ui_timerText.timer = timer;
        ui_levelInfo.World = World;
        ui_levelInfo.Level = Level;
        ui_levelInfo.levelInfoTimer = levelInfoTimer;
    }

    void Timer()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else
        {
            timer = 0;
            sceneFader.SwitchScene(Application.loadedLevel);
        }
    }

    void CalculateFps ()
    {
        timeleft -= Time.deltaTime;
		accum += Time.timeScale/Time.deltaTime;
		++frames;
		
		// Interval ended - update GUI text and start new interval
        if (timeleft <= 0.0)
        {
            // display two fractional digits (f2 format)
            fps = accum / frames;
            format = System.String.Format("{0:F2} FPS", fps);

            //	DebugConsole.Log(format,level);
            timeleft = updateInterval;
            accum = 0.0F;
            frames = 0;
        }

        ui_debug.fps = format;
    }
}
