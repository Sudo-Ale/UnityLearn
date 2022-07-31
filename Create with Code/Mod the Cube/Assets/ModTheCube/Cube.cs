using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    //renderer attached to the cube
    public MeshRenderer Renderer;

    void Start()
    {
        StartSizeCube();
        StartColorCube();

        InvokeRepeating(nameof(ChangeColor), 1f, 1f);
    }
    
    void Update()
    {
        CubeRotation();
    }

    void StartSizeCube()
    {
        //new cube position on start
        transform.position = new Vector3(2, 2, 2);
        //cube size increased on start
        transform.localScale = Vector3.one * 1.5f;
    }
    void StartColorCube()
    {
        Material material = Renderer.material;
        //material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
        material.color = new Color(0.1f, 0.8f, 0.2f, 0.5f);
    }
    
    void CubeRotation() 
    {
        //rotation speed per angle (x, y, z)
        transform.Rotate(0.0f, 1.0f * Time.deltaTime, 10.0f * Time.deltaTime);
    }

    // Change position randomly
    void ChangePosition() 
    {
        var xPos = Random.Range(2, 3);
        var yPos = Random.Range(1, 4);
        var zPos = Random.Range(0, 5);

        transform.position = new Vector3(xPos, yPos, zPos);
    }

    //Change color applied to variables, increased over calling
    void ChangeColor()
    {
        Material material = Renderer.material;
        material.color = new Color(Random.value, Random.value, Random.value);
    }
}
