using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float spawnCooldown = 1.0f;

    private bool canSummmon = true;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canSummmon)
        {
            StartCoroutine(ShootWithCooldown());
        }
    }
    private IEnumerator ShootWithCooldown()
    {
        canSummmon = false;

        // Istanzia il proiettile
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

        // Aspetta il cooldown
        yield return new WaitForSeconds(spawnCooldown);

        canSummmon = true;
    }

}
