using UnityEngine;
using System.Collections;

public class GameOverUI : MonoBehaviour {

    private GameObject gameOverText;

    void Awake()
    {
        UIEventsHandler.OnPlayerDeath += this.PlayerDeath;

        gameOverText = this.gameObject.GetChild("UI_GameOverText");
        gameOverText.gameObject.SetActive(false);
    }

    void OnDisable()
    {
        UIEventsHandler.OnPlayerDeath -= this.PlayerDeath;
    }

    public void PlayerDeath()
    {
        gameOverText.gameObject.SetActive(true);
    }
}
