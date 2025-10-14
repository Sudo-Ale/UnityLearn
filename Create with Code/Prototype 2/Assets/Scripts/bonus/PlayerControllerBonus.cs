using UnityEngine;

public class PlayerControllerBonus : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    public float speed = 10.0f;
    public float xRange = 20.0f;

    public float zRangeTop = 15.0f;
    public float zRangeBottom = -1.0f;

    public GameObject projectilePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        //KeepInBound();
        KeepInBoundFixed();

        LaunchProjectile();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Animal"))
        {
            
        }
    }
    private void MovePlayer()
    {
        // move the player left and right
        horizontalInput = Input.GetAxis("Horizontal");

        // move the player forward and backward
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
    }

    //private void KeepInBound()
    //{
    //    if (transform.position.x < -xRange)
    //    {
    //        //transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
    //        transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
    //    }

    //    if (transform.position.x > xRange)
    //    {
    //        transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
    //    }

    //    if (transform.position.z > zRangeTop)
    //    {
    //        transform.position = new Vector3(transform.position.x, transform.position.y, zRangeTop);
    //    }

    //    if (transform.position.z < zRangeBottom)
    //    {
    //        transform.position = new Vector3(transform.position.x, transform.position.y, zRangeBottom);
    //    }
    //}
    private void KeepInBoundFixed() 
    {
        // Clamp the X position within the left and right range
        float clampedX = Mathf.Clamp(transform.position.x, -xRange, xRange);
        
        // Clamp the Z position within the top and bottom range
        float clampedZ = Mathf.Clamp(transform.position.z, zRangeBottom, zRangeTop);

        // Update the player's position with the clamped values
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);
    }
    private void LaunchProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}