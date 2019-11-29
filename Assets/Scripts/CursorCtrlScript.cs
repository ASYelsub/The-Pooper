using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorCtrlScript : MonoBehaviour
{
    public static CursorCtrlScript me;
    public bool canMove = false;
    public Camera cam;
    public Vector3 center;
    public Vector3 cursorPos;
    public Vector3 startMousePos;
    public Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        me = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            //Vector3 mousePos = Input.mousePosition;
            //mousePos.z = 2f;
            //cursorPos = cam.ScreenToWorldPoint(mousePos);
            //transform.localPosition = new Vector3(cursorPos.x,cursorPos.y,2);
            
            Vector3 currentPos = Input.mousePosition;
            Vector3 diff = currentPos - startMousePos;
            Vector3 pos = startPos + diff;
            transform.position = pos;
            
        }
        else
        {
            transform.localPosition = center;
        }
    }
}
