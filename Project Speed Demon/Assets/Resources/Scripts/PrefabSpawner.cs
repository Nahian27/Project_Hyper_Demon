using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public float prefabLenth = 200, zSpawn, spawnAfter;
    public int prefabsOnScreen;
    public bool randomRotation;
    public Vector3[] randomRotations;
    private Transform cube;
    private List<GameObject> activePrefabs;

    private void Start()
    {
        activePrefabs = new List<GameObject>();
        cube = GameObject.FindGameObjectWithTag("Player").transform;

        //for (int i = 0; i < prefabsOnScreen; i++)
        //{
        //    SpawnPrefabs(Random.Range(0, prefabs.Length));
        //}
        StartCoroutine(SpawningPrefabs());
    }
    private void Update()
    {
        //    if (cube.transform.position.z > (zSpawn + prefabLenth * prefabsOnScreen))
        //    {
        //        SpawnPrefabs(Random.Range(0, prefabs.Length));
        //        DeletePrefab();
        //    }
    }
    private void SpawnPrefabs(int BlockPrefabIndex)
    {
        GameObject go;
        if (randomRotation) go = Instantiate(prefabs[BlockPrefabIndex], transform.forward * zSpawn,
            Quaternion.Euler(randomRotations[Random.Range(0, randomRotations.Length)]));

        else go = Instantiate(prefabs[BlockPrefabIndex], transform.forward * zSpawn, Quaternion.identity);

        zSpawn += prefabLenth;
        //activePrefabs.Add(go);
    }

    private void DeletePrefab()
    {
        Destroy(activePrefabs[0]);
        activePrefabs.RemoveAt(0);
    }

    IEnumerator SpawningPrefabs()
    {
        while (true)
        {
            for (int i = 0; i < prefabsOnScreen; i++)
            {
                SpawnPrefabs(Random.Range(0, prefabs.Length));
            }
            yield return new WaitForSeconds(spawnAfter);
            zSpawn = 150;
        }
    }
}