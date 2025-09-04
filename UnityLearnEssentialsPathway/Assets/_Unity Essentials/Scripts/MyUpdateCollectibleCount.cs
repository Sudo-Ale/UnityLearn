using System; // Required for Type handling
using TMPro;
using UnityEngine;
using UnityEngine.VFX;

public class MyUpdateCollectibleCount : MonoBehaviour
{

    public ParticleSystem winEffect; // Reference to the GameObject to activate
    public AudioSource winSound; // Reference to the Audio Source
    private bool hasWin = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCollectible();
    }

    void UpdateCollectible() 
    {
        int totalCollectibles = 0;
        
        // Check and count objects of type Collectible
        Type collectibleType = Type.GetType("Collectible");
        if (collectibleType != null)
        {
            totalCollectibles += UnityEngine.Object.FindObjectsByType(collectibleType, FindObjectsSortMode.None).Length;
        }

        if (totalCollectibles == 0 && !hasWin)
        {
            winEffect.Play();
            winSound.Play();

            hasWin = true;
        }
    }
}
