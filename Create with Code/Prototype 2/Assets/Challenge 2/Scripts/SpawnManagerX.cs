using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;

    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBallsWithRandomInterval());
    }

    IEnumerator SpawnBallsWithRandomInterval()
    {
        // wait the initial delay
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            SpawnRandomBall();

            // wait for a random interval before spawning the next ball
            float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(randomInterval);
        }
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // random index for ball selection
        int ballIndex = Random.Range(0, ballPrefabs.Length);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[0].transform.rotation);
    }

}
