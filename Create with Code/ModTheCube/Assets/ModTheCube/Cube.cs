using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public Material material;

    public float speed = 0.5f;
    public float rotationSpeed = 10.0f;

    void Start()
    {
        //transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        material = Renderer.material;

        StartCoroutine(ChangeColorRoutine());
        StartCoroutine(ChangePositionRoutine());
    }


    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

    // Coroutine to change position every 2 seconds
    private IEnumerator ChangePositionRoutine()
    {
        while (true)
        {
            ChangePosition();
            yield return new WaitForSeconds(2.0f);
        }
    }
    // Change the position to a random value between 0 and 8 for x, y, z
    private void ChangePosition()
    {
        transform.position = new Vector3(Random.Range(0, 8), Random.Range(0, 8), Random.Range(0, 8));
    }

    // Coroutine to change color every second
    IEnumerator ChangeColorRoutine()
    {
        while (true)
        {
            ChangeColor();
            yield return new WaitForSeconds(1.0f);
        }
    }
    // Change the color of the material to a random value between 0 and 1 for r, g, b, a
    void ChangeColor()
    {
        material.color = new Color(Random.value, Random.value, Random.value, Random.value);
    }
}
