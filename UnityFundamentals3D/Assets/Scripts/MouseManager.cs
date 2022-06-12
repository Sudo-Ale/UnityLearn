using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    //Know what objects are clickable
    public LayerMask clickableLayer;

    //Swap cursors per object
    public Texture2D pointer;   //Normal pointer
    public Texture2D target;    //Clickable objects
    public Texture2D doorway;  //Cursor for doorways    
    public Texture2D combat;    //Cursor for combat

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

            if (hit.collider.gameObject.tag == "Doorway")
            {
                Cursor.SetCursor(doorway, new Vector2(16, 16), CursorMode.Auto);
                door = true;
            }
            else
            {
                Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
            }
        }
        else
        {
            Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
        }
    }
}
