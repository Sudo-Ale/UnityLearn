using System.Collections;
using UnityEngine;

public class SpawnManagerBonus : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    // top spawn
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;

    // left right spawn
    private float spawnRangeXLeftRight = 28f;
    private float spawnRangeZLeftRightTop = 15f;
    private float spawnRangeZLeftRightBottom = -1.5f;


    private float startDelay = 2.0f;
    //private float spawnInterval = 1.5f;

    private float minSpawnInterval = 0.5f;
    private float maxSpawnInterval = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);

        StartCoroutine(SpawnRandomAnimalBonus());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnRandomAnimalBonus()
    {
        // initial delay
        yield return new WaitForSeconds(startDelay);

        // spawn animals at random intervals
        while (true)
        {
            SpawnRandomAnimal();

            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnRandomAnimal()
    {
        // Randomly generate which direction to spawn from
        int randomAnimalSpawn = Random.Range(0, 3);
        if (randomAnimalSpawn == 0)
        {
            SpawnRandomAnimalTop();
        }
        else if (randomAnimalSpawn == 1)
        {
            SpawnRandomAnimalLeft();
        }
        else
        {
            SpawnRandomAnimalRight();
        }
    }

    void SpawnRandomAnimalTop()
    {
        // Randomly generate animal index and spawn position
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
    void SpawnRandomAnimalLeft()
    {
        // Randomly generate animal index and spawn position
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPos = new(-spawnRangeXLeftRight, 0, Random.Range(spawnRangeZLeftRightBottom, spawnRangeZLeftRightTop));
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, 90, 0));
    }
    void SpawnRandomAnimalRight()
    {
        // Randomly generate animal index and spawn position
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPos = new(spawnRangeXLeftRight, 0, Random.Range(spawnRangeZLeftRightBottom, spawnRangeZLeftRightTop));
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, -90, 0));
    }
}
