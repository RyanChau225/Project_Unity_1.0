using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkRadius;
    Vector3 noTerrainPoisition;
    public LayerMask terrainMask;
    public GameObject currentChunk;
    PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
    }

    void ChunkChecker()
    {
        if (!currentChunk)
        {
            return;
        }

        if(pm.moveDir.x > 0 && pm.moveDir.y == 0) //right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkRadius, terrainMask))
            {
                noTerrainPoisition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }

        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y == 0) //left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkRadius, terrainMask))
            {
                noTerrainPoisition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }

        }
        else if (pm.moveDir.x == 0 && pm.moveDir.y > 0 ) //up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkRadius, terrainMask))
            {
                noTerrainPoisition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }

        }
        else if (pm.moveDir.x == 0 && pm.moveDir.y < 0) //down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkRadius, terrainMask))
            {
                noTerrainPoisition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }

        }
        else if (pm.moveDir.x > 0 && pm.moveDir.y > 0) //right up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right Up").position, checkRadius, terrainMask))
            {
                noTerrainPoisition = currentChunk.transform.Find("Right Up").position;
                SpawnChunk();
            }

        }
        else if (pm.moveDir.x > 0 && pm.moveDir.y < 0) //right down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right Down").position, checkRadius, terrainMask))
            {
                noTerrainPoisition = currentChunk.transform.Find("Right Down").position;
                SpawnChunk();
            }

        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y > 0) //left up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Up").position, checkRadius, terrainMask))
            {
                noTerrainPoisition = currentChunk.transform.Find("Left Up").position;
                SpawnChunk();
            }

        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y < 0) //left down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Down").position, checkRadius, terrainMask))
            {
                noTerrainPoisition = currentChunk.transform.Find("Left Down").position;
                SpawnChunk();
            }

        }

    }

    void SpawnChunk()
    {
        int rand = Random.Range(0, terrainChunks.Count);
        Instantiate(terrainChunks[rand], noTerrainPoisition, Quaternion.identity);
    }
}
