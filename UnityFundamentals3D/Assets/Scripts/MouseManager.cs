using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    //Know what objects are clickable
    public LayerMask clickableLayer;

    //Swap cursors per object
    public Texture2D pointer;   //Normal pointer
    public Texture2D pointerNoClick;//Not clickable
    public Texture2D target;    //Clickable objects
    public Texture2D doorway;  //Cursor for doorways  
    public Texture2D combat;    //Cursor for combat

    public EventVector3 OnClickEnvironment;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        //Raycast
        //Origin = camera.main.screenpointtoray
        //vector3 position = input.mouseposition
        //raycast hit
        //lenght of ray = 50
        //Layermask

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, clickableLayer.value))
        {
            //any time click on something, we re make sure that door is false, normal word iteraction
            bool door = false;
            bool item = false;

            //tags
            if (hit.collider.gameObject.tag == "Doorway")
            {
                Cursor.SetCursor(doorway, new Vector2(16, 16), CursorMode.Auto);
                door = true;
            }
            else if (hit.collider.gameObject.tag == "Item")
            {
                Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
                item = true;
            }
            else
            {
                Cursor.SetCursor(pointer, new Vector2(16, 16), CursorMode.Auto);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (door)
                {
                    Transform doorway = hit.collider.gameObject.transform;
                    OnClickEnvironment.Invoke(doorway.position);

                    Debug.Log("DOOR");
                }
                else if (item)
                {
                    Transform itemPos = hit.collider.gameObject.transform;
                    OnClickEnvironment.Invoke(itemPos.position);

                    Debug.Log("ITEM");
                }
                else
                {
                    OnClickEnvironment.Invoke(hit.point);
                }
            }
        }
        else
        {
            Cursor.SetCursor(pointerNoClick, Vector2.zero, CursorMode.Auto);
        }
    }
}

[System.Serializable]//available inside the inspector
public class EventVector3 : UnityEvent<Vector3> { }