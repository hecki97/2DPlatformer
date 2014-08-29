using UnityEngine;
using System.Collections;

public class TouchControlsUI : MonoBehaviour {

    private GameObject buttons;

    void Awake()
    {
        UIEventsHandler.OnSceneRestart += this.SceneRestart;
        UIEventsHandler.OnPlayerDeath += this.SceneRestart;
        UIEventsHandler.RuntimePlatformIsMobile += this.IsMobile;

        buttons = this.gameObject.GetChild("Buttons");

        buttons.gameObject.SetActive(false);
    }

    void OnDisable()
    {
        UIEventsHandler.OnSceneRestart -= this.SceneRestart;
        UIEventsHandler.OnPlayerDeath -= this.SceneRestart;
        UIEventsHandler.RuntimePlatformIsMobile -= this.IsMobile;
    }

    public void IsMobile()
    {
        buttons.gameObject.SetActive(true);
    }

    public void SceneRestart()
    {
        buttons.gameObject.SetActive(false);
    }
}
