using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    public List<GameObject> propSpawnPoints;
    public List<GameObject> propPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        SpawnProps();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnProps()
    {
        foreach (GameObject sp in propSpawnPoints)
        {
            int rand = Random.Range(0, propPrefabs.Count);
            Vector3 spawnPosition = new Vector3(sp.transform.position.x, sp.transform.position.y, -1); // Set Z to -1
            GameObject prop = Instantiate(propPrefabs[rand], spawnPosition, Quaternion.identity);
            prop.transform.parent = sp.transform;
        }
    }

}
