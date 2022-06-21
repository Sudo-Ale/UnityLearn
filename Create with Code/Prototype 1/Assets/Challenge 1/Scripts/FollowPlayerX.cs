using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    //reference to player
    public GameObject plane;
    //start position of camera
    private Vector3 offset = new Vector3(30, 0, 10);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //camera follow player position
        transform.position = plane.transform.position + offset;
    }
}
