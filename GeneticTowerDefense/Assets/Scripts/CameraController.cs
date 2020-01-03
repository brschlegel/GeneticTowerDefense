using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    
    public bool move = true;
    public float scrollSpeed = 5;
    public float minY = 10;
    public float maxY = 320;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("."))
            move = !move;
        //ability to disable camera movement
        if (!move)
            return;
        
        
        //Move up
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.forward  * panSpeed * Time.deltaTime, Space.World);
        }
        //Move down
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        //Move Left
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        //Move right
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * scrollSpeed * 1000 * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;

    }
}
