using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    float spawnRangeX = 20;
    float spawnPosZ = 20;

    // Update is called once per frame
    void Update()
    {
        var animalIndex = Random.Range(0, animalPrefabs.Length);
        var spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        }
    }
}
