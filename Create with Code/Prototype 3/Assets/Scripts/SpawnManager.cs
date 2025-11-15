using System;
using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new(30, 0, 0);

    public float startDelay = 2;
    public float repeatRate = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        StartCoroutine(SpawnObstacleRoutine());
    }

    private IEnumerator SpawnObstacleRoutine()
    {
        yield return new WaitForSeconds(startDelay);
        while (true)
        {
            SpawnObstacle();

            // Wait random seconds between 1, 3 seconds
            float waitTime = UnityEngine.Random.Range(1f, 3f);
            yield return new WaitForSeconds(waitTime);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle() 
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
