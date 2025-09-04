using UnityEngine;

public class Block : MonoBehaviour
{
    public AudioClip collapseSound;
    private bool hasCollided = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!hasCollided && (collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Ground")))
        {
            // Play the audio source attach to the collectible at the collectible's position
            AudioSource.PlayClipAtPoint(collapseSound, transform.position);

            hasCollided = true;
        }
    }
}