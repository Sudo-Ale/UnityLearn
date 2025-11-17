using System;
using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new(30, 0, 0);

    public float startDelay = 2;
    public float minRange = 1f;
    public float maxRange = 3f;

    private PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        //InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        StartCoroutine(SpawnObstacleRoutine());
    }

    private IEnumerator SpawnObstacleRoutine()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            SpawnObstacle();

            // Wait random seconds between min, max range seconds
            float waitTime = UnityEngine.Random.Range(minRange, maxRange);
            yield return new WaitForSeconds(waitTime);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle() 
    {
        if (playerController.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
