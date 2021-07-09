using System.Collections.Generic;
using UnityEngine;

public class HallManager : MonoBehaviour
{
    public GameObject[] hallPrefabs;
    public GameObject cube;
    public float BlockPrefabLenth, zSpawn, delayOfDestroy;
    private List<GameObject> activeHalls;

    private void Start()
    {
        activeHalls = new List<GameObject>();
    }
    private void Update()
    {
        if (cube.GetComponent<Transform>().position.z > zSpawn - BlockPrefabLenth)
        {
            SpawnHalls(Random.Range(0, hallPrefabs.Length));
            DestroyHalls();
        }
    }
    private void SpawnHalls(int BlockPrefabIndex)
    {
        GameObject go;
        go=Instantiate(hallPrefabs[BlockPrefabIndex], transform.forward * zSpawn, transform.rotation);
        zSpawn += BlockPrefabLenth;
        activeHalls.Add(go);
    }
    private void DestroyHalls()
    {
        Destroy(activeHalls[0], delayOfDestroy);
        activeHalls.RemoveAt(0);
    }
}
