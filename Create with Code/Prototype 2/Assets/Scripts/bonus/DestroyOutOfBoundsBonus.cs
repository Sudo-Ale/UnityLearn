using UnityEngine;

public class DestroyOutOfBoundsBonus : MonoBehaviour
{
    private float topBound = 30.0f;
    private float lowerBound = -10.0f;
    private float sideBound = 35.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // destroy any object out the view of the player
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -sideBound) 
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > sideBound) 
        {
            Destroy(gameObject);
        }
    }
}
