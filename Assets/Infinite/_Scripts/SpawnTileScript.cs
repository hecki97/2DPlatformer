using UnityEngine;
using System.Collections;

public class SpawnTileScript : MonoBehaviour {

    public GameObject prefab;
    Vector2 oldTilePos = new Vector2();

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Vector2 tilePos = new Vector2();
        tilePos.x = Mathf.RoundToInt(ray.origin.x);
        tilePos.y = Mathf.RoundToInt(ray.origin.y);

        if (tilePos != oldTilePos)
        {
            prefab.transform.position = tilePos;
            oldTilePos = tilePos;
        }

        string name = string.Format(prefab.name + "_{0}_{1}_{2}", prefab.transform.position.z, tilePos.y, tilePos.x);
        CreateTile(tilePos, name);
    }

    void CreateTile(Vector2 tilePos, string name)
    {
        if (!GameObject.Find(name))
        {
            Vector3 pos = new Vector3(tilePos.x, tilePos.y, prefab.transform.position.z);
            GameObject go = (GameObject)Instantiate(prefab, pos, Quaternion.identity);
            go.name = name;
            StoreTile(go);
        }
    }

    void StoreTile(GameObject go)
    {
        if (GameObject.Find("Tiles/" + prefab.name) != null)
            go.transform.parent = GameObject.Find("Tiles/" + prefab.name).transform;
        else
        {
            GameObject newGo = new GameObject(prefab.name);
            newGo.transform.parent = GameObject.Find("Tiles").transform;
        }
    }
}
