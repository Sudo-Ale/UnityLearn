using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject onCollectEffect;
    public AudioClip collectSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Play the audio source attach to the collectible at the collectible's position
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

            //Instantiate the effect at the collectible's position and rotation
            Instantiate(onCollectEffect, transform.position, transform.rotation);

            //Destroy the collectible when it collides with the player
            Destroy(gameObject);
        }
    }
}
