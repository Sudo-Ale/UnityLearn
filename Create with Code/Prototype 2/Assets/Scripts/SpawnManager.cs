using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    float spawnRangeX = 20;
    float spawnPosZ = 20;
    float startDelay = 1.5f;
    float spawnInterval = 1.5f;

    void Start()
    {
        //keep call the method in parenthesees
        InvokeRepeating(nameof(SpawnRandomAnimal), startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRandomAnimal() 
    {
        //index of animal in arr and position of animal spawn
        var animalIndex = Random.Range(0, animalPrefabs.Length);
        var spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        //instantiate, creates copy of objects
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
