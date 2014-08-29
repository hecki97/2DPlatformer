using UnityEngine;
using System.Collections;

public class UIEventsHandler : MonoBehaviour {

    private HealthController healthController;
    private UIController uiController;


    public delegate void UIEventHandler();
    public static event UIEventHandler OnSceneStart;
    public static event UIEventHandler OnPlayerDeath;
    public static event UIEventHandler OnSceneRestart;
    public static event UIEventHandler RuntimePlatformIsMobile;

    public static void SceneStart()
    {
        if (OnSceneStart != null)
            OnSceneStart();
    }

    public static void PlayerDeath()
    {
        if (OnPlayerDeath != null)
            OnPlayerDeath();
    }

    public static void SceneRestart()
    {
        if (OnSceneRestart != null)
            OnSceneRestart();
    }

    public static void  IsMobile()
    {
        if (RuntimePlatformIsMobile != null)
            RuntimePlatformIsMobile();
    }

	// Use this for initialization
	void Start()
    {
        healthController = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
        uiController = GetComponent<UIController>();
        SceneStart();

        CheckRuntimePlatform();
	}

	// Update is called once per frame
	void Update () {
        CheckPlayerHealth();
	}

    void CheckRuntimePlatform()
    {
        if (
                Application.platform == RuntimePlatform.WindowsWebPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer ||   //Windows
                Application.platform == RuntimePlatform.OSXWebPlayer || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer ||   //Mac OSX
                Application.platform == RuntimePlatform.LinuxPlayer //Linux
           )
            IsMobile();
        else
            Debug.Log("Disabled Touch Controls");
    }

    void CheckPlayerHealth()
    {
        if (healthController.currentHealth <= 0f && healthController.lifePoints == 0f)
            PlayerDeath();

        if (healthController.currentHealth <= 0f && healthController.lifePoints > 0f)
            SceneRestart();
    }
}
