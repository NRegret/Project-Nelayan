using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PrefabRadiusPair
{
    public GameObject prefab;
    public float minRadius;
    public float maxRadius;
}

public class ObjectSpawner : MonoBehaviour
{
    public PrefabRadiusPair[] prefabRadiusPairs; 
    public float spawnRange = 10f; 
    public int maxPrefabs = 10; 
    [SerializeField]
    private int currentPrefabCount = 0; 

    private List<GameObject> spawnedPrefabs = new List<GameObject>(); 

    void Start()
    {
        InvokeRepeating("SpawnPrefab", 0.001f, 0.002f);
    }

    void SpawnPrefab()
    {
        
        if (currentPrefabCount >= maxPrefabs)
        {
            return; 
        }

        
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRange, spawnRange), 0f, Random.Range(-spawnRange, spawnRange));

        
        foreach (PrefabRadiusPair pair in prefabRadiusPairs)
        {
            if (Vector3.Distance(spawnPosition, transform.position) >= pair.minRadius && Vector3.Distance(spawnPosition, transform.position) <= pair.maxRadius)
            {
                
                GameObject newPrefab = Instantiate(pair.prefab, spawnPosition, Quaternion.identity);
                spawnedPrefabs.Add(newPrefab); 
                currentPrefabCount++; 
                return; 
            }
        }
    }

    
    public void PrefabDestroyed(GameObject destroyedPrefab)
    {
        if (spawnedPrefabs.Contains(destroyedPrefab))
        {
            spawnedPrefabs.Remove(destroyedPrefab); 
            currentPrefabCount--; 
        }
    }
}
