using UnityEngine;
using System.Collections;

public class LifePointsUI : MonoBehaviour {

    public float maxLifePoints = 3;
    public float delay = 1.25f;

	private float lifePoints;
	private string lifePointsText = "LifePoint";

	// Use this for initialization
	void Start () {
		lifePoints = InventoryManager.inventory.GetItems(lifePointsText);

        StartCoroutine(SubLifePoint(delay));
	}

    IEnumerator SubLifePoint(float delay)
    {
        GUIStyle style = new GUIStyle();
        style.richText = true;
        guiText.text = lifePoints.ToString();
        yield return new WaitForSeconds(delay);
        lifePoints -= 1;
        guiText.text = lifePoints.ToString();
        yield return new WaitForSeconds(delay);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
