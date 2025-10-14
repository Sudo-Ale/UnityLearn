using UnityEngine;
using UnityEngine.UI;

public class FeedAnimal : MonoBehaviour
{
    private float maxHunger = 100f;
    private float currentHunger = 0f;

    public Slider hungerSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hungerSlider = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Food"))
        {
            Feed();

            // already destroy food in DetectCollisionBonus script
            //Destroy(other.gameObject);
        }
    }

    private void Feed()
    {
        currentHunger += 33.5f;
        currentHunger = Mathf.Clamp(currentHunger, 0f, maxHunger);

        hungerSlider.value = currentHunger / maxHunger;

        if (currentHunger >= maxHunger)
        {
            // Animal is fully fed, destroy it
            Destroy(gameObject);
            GameManagerBonus.instance.AddScore(1);
        }
    }
}
