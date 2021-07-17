using System.Collections;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public float prefabLenth = 200, zSpawn, spawnAfter;
    public int prefabsOnScreen;
    public bool randomRotation;
    public Vector3[] randomRotations;

    private void Start()
    {
        StartCoroutine(SpawningPrefabs());
    }
    private void SpawnPrefabs(int BlockPrefabIndex)
    {
        GameObject go;
        if (randomRotation) go = Instantiate(prefabs[BlockPrefabIndex], transform.forward * zSpawn,
            Quaternion.Euler(randomRotations[Random.Range(0, randomRotations.Length)]));

        else go = Instantiate(prefabs[BlockPrefabIndex], transform.forward * zSpawn, Quaternion.identity);

        zSpawn += prefabLenth;
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
            zSpawn = 100;
        }
    }
}