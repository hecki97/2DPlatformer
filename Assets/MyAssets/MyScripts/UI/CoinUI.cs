using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour {

    private Text coinText;

	void Awake()
	{
        coinText = this.gameObject.GetChild("UI_CointText").GetComponent<Text>();

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
	void Update () {
        coinText.text = "x " + InventoryManager.inventory.GetItems("coin").ToString("0");
	}
}
