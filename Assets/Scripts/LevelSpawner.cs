using UnityEngine;
using System.Collections.Generic;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject oreObject;

    [SerializeField]
    private GameObject barrel;

    [SerializeField]
    private GameObject chunk;

    private int chunkCount;

    private int spawnFrequencyMod;

    public List<GameObject> chunkList = new List<GameObject>();

    public List<OreSO> oreSOs = new List<OreSO>();

    void Start()
    {
        chunkList.Add(GameObject.FindGameObjectWithTag("Chunk"));
    }

    public void SpawnChunk()
    {
        chunkCount++;
        if (chunkCount % 5 == 0)
            spawnFrequencyMod++;

        float spawnX = 48f * chunkCount + 5f;
        GameObject chunkSpawned = Instantiate(chunk, new Vector2(spawnX, 0f), Quaternion.identity);
        chunkSpawned.name = "Chunk " + chunkCount;
        PopulateChunk(chunkSpawned);

        chunkList.Add(chunkSpawned);

        if (chunkList.Count > 3)
        {
            Destroy(chunkList[0]);
            chunkList.Remove(chunkList[0]);
        }
    }

    private void PopulateChunk(GameObject chunk)
    {
        for (int i = 0; i < 5; i++)
        {
            int roof = Random.Range(0, 2);
            float yValue;
            float xRot;
            if (roof == 1)
            {
                yValue = 7.75f;
                xRot = 180f;
            }
            else
            {
                yValue = 0.25f;
                xRot = 0f;
            }

            float spawnRange = 30 + spawnFrequencyMod;
            Mathf.Clamp(spawnRange, 15, 999);

            float doSpawn = Random.Range(0, 100);
            if (doSpawn <= spawnRange)
            {
                Vector2 spawnPoint = new Vector2(i * 6f + 1.5f, yValue);
                GameObject oreSpawn = Instantiate(oreObject, chunk.transform.position + (Vector3)spawnPoint, Quaternion.Euler(new Vector2(xRot, 0f)));
                oreSpawn.GetComponent<OreProperties>().SetOre(RandomOre());
                oreSpawn.transform.parent = chunk.transform;
            }
        }
    }

    private OreSO RandomOre()
    {
        OreSO oreToReturn;

        int randomValue = Random.Range(0, 100);

        if (randomValue < 50)
            oreToReturn = oreSOs[0];

        else if (randomValue < 80)
            oreToReturn = oreSOs[1];
        else
            oreToReturn = oreSOs[2];

        return oreToReturn;
    }
}
