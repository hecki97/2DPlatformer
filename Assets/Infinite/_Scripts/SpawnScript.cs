using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    public GameObject[] obj;
    public float spawnMin = 1f;
    public float spawnMax = 2f;
    public float cooldown = 1.5f;
    public bool isActive = false;

    private Vector2 tilePos;
    private Vector2 oldTilePos = new Vector2();
    private GameObject objPrefab;
    string name;

    // Use this for initialization
    void Start()
    {
        objPrefab = obj[Random.Range(0, obj.GetLength(0))];
        
        if (isActive)
            CreateTile(tilePos, name);
        else
            StartCoroutine(StartCooldown());
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        tilePos.x = Mathf.RoundToInt(ray.origin.x);
        tilePos.y = Mathf.RoundToInt(ray.origin.y);

        if (tilePos != oldTilePos)
        {
            objPrefab.transform.position = tilePos;
            oldTilePos = tilePos;
        }

        name = string.Format("obj_{0}_{1}_{2}", objPrefab.transform.position.z, tilePos.y, tilePos.x);
    }

    void CreateTile(Vector2 tilePos, string name)
    {
        if (!GameObject.Find(name))
        {
            Vector3 pos = new Vector3(tilePos.x, tilePos.y, objPrefab.transform.position.z);
            GameObject go = (GameObject)Instantiate(objPrefab, pos, Quaternion.identity);
            go.name = name;
            //StoreTile(go);
        }
        Invoke("Start", Random.Range(spawnMin, spawnMax));
    }

    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        isActive = true;
        Invoke("Start", Random.Range(spawnMin, spawnMax));
    }
}
