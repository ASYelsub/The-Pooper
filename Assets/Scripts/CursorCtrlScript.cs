using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorCtrlScript : MonoBehaviour
{
    public static CursorCtrlScript me;
    public bool canMove = false;
    public Camera cam;
    public Vector3 center;
    public Vector3 cursorPos;
    public Vector3 startMousePos;
    public Vector3 startPos;

    // for changing cursor
    public GameObject emailC;
    public GameObject talkC;
    public GameObject eyeC;
    public int cursorState;

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
            Vector3 currentPos = Input.mousePosition;
            Vector3 diff = currentPos - startMousePos;
            Vector3 pos = startPos + diff;
            transform.position = pos;
            
        }
        else
        {
            transform.localPosition = center;
        }

        // changing cursor image
        if (cursorState == 0) // default cursor
        {
            GetComponent<Image>().enabled = true;
            emailC.SetActive(false);
            talkC.SetActive(false);
            eyeC.SetActive(false);
        }
        else if (cursorState == 1) // email cursor
        {
            GetComponent<Image>().enabled = false;
            emailC.SetActive(true);
            talkC.SetActive(false);
            eyeC.SetActive(false);
        }
        else if (cursorState == 2) // talk cursor
        {
            GetComponent<Image>().enabled = false;
            emailC.SetActive(false);
            talkC.SetActive(true);
            eyeC.SetActive(false);
        }
        else if (cursorState == 3) // eye cursor
        {
            GetComponent<Image>().enabled = false;
            emailC.SetActive(false);
            talkC.SetActive(false);
            eyeC.SetActive(true);
        }
    }
}
