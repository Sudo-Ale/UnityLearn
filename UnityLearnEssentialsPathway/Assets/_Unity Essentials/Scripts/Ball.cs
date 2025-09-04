using UnityEngine;

public class Ball : MonoBehaviour
{
    public AudioClip bounceSound;

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
        if(collision.gameObject.CompareTag("Ground"))
        {
            //Play the audio source attach to the collectible at the collectible's position
            AudioSource.PlayClipAtPoint(bounceSound, transform.position);
        }
    }
}
