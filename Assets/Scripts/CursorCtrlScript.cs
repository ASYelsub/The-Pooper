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
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 2.254f;
            cursorPos = cam.ScreenToWorldPoint(mousePos);
            transform.localPosition = new Vector3(cursorPos.x,cursorPos.y,2);
            
        }
        else
        {
            transform.localPosition = center;
        }
    }
}
