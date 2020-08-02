using UnityEngine;
using System.Collections.Generic;

public class LevelSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;

    private int chunkCount;

    public List<OreSO> oreSOs = new List<OreSO>();

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
        SpawnChunk();
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, Transform parent)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.parent = parent;
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    public void SpawnChunk()
    {
        float spawnX = 48f * chunkCount;
        GameObject chunkSpawned = SpawnFromPool("Chunk", new Vector2(spawnX, 0f), Quaternion.identity, null);
        chunkSpawned.name = "Chunk " + chunkCount;
        if (chunkCount > 1)
            PopulateChunk(chunkSpawned);        
        chunkCount++;
    }

    private void PopulateChunk(GameObject chunk)
    {
        ClearChunk(chunk);

        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 2; y++)
            {
                float xValue = -21f + (x * 6f);
                float yValue = 0.5f + (y * 7f);
                float xRot = y * 180f;
                int spawn = Random.Range(0, 100);

                if (spawn < 10)
                {
                    SpawnOre(new Vector2(xValue, yValue), xRot, chunk);
                }
                else if (spawn < 15)
                {
                    if (y == 0)
                    {
                        SpawnBarrel(new Vector2(xValue, yValue - 0.5f), xRot, chunk);
                    }

                }
                else if (spawn < 17)
                {
                    if (y == 0)
                    {
                        SpawnLava(new Vector2(xValue, yValue - 3), xRot, chunk);
                    }
                }
            }
        }
    }

    private void ClearChunk(GameObject chunk)
    {
        for (int i = 3; i < chunk.transform.childCount; i++)
        {
            chunk.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void SpawnOre(Vector2 spawnPoint, float xRot, GameObject chunk)
    {
        GameObject oreSpawn = SpawnFromPool("Ore", chunk.transform.position + (Vector3)spawnPoint, Quaternion.Euler(new Vector2(xRot, 0f)), chunk.transform);
        oreSpawn.GetComponent<OreProperties>().SetOre(RandomOre());
    }

    private void SpawnBarrel(Vector2 spawnPoint, float xRot, GameObject chunk)
    {
        SpawnFromPool("Barrel", chunk.transform.position + (Vector3)spawnPoint, Quaternion.Euler(new Vector2(xRot, 0f)), chunk.transform);
    }

    private void SpawnLava(Vector2 spawnPoint, float xRot, GameObject chunk)
    {
        SpawnFromPool("Lava", chunk.transform.position + (Vector3)spawnPoint, Quaternion.Euler(new Vector2(xRot, 0f)), chunk.transform);
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
