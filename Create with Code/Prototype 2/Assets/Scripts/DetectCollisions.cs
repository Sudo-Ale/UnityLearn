using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //mono, on collide
    private void OnTriggerEnter(Collider other)
    {
        //food
        Destroy(gameObject);
        //animal
        Destroy(other.gameObject);
    }
}
