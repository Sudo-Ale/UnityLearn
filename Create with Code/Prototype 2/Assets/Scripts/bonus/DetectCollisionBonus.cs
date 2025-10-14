using UnityEngine;

public class DetectCollisionBonus : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // added tag "Animal" for avoid detecting collision with the player
        // destroy both the projectile and the animal
        if (other.transform.CompareTag("Animal"))
        {
            Destroy(gameObject);
            //Destroy(other.gameObject);

            //GameManagerBonus.instance.AddScore(1);
        }
    }
}