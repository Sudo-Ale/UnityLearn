using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowBound = -15;

    // Update is called once per frame
    void Update()
    {
        //destroy all gameobject out of the player view
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowBound)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
