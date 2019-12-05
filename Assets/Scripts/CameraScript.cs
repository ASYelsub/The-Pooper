using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    Transform cam;

    float yrot;
    float xrot;

    float sensitivity = 180;

    public GameObject hitMarker;

    int layerMask = 1 << 8;

    Vector3 startPos;
    Vector3 camUp;
    bool goUp;
    bool moving;

    public Transform HAND;

    public float downAim = .25f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        camUp = new Vector3(startPos.x, startPos.y + .3f, startPos.z);
        layerMask = ~layerMask;
        cam = Camera.main.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        xrot += -Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;
        yrot += Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
        xrot = Mathf.Clamp(xrot, -90, 90);
        cam.rotation = Quaternion.Euler(xrot, yrot, 0);

        Shooting();
        CameraBob();
    }

    void Shooting()
    {
        RaycastHit hit;
        Physics.Raycast(new Vector3(transform.position.x, transform.position.y - downAim, transform.position.z), transform.forward, out hit, Mathf.Infinity, layerMask);
        //Physics.Raycast(HAND.position, new Vector3(transform.forward.x, transform.forward.y - .05f, transform.forward.z), out hit, Mathf.Infinity, layerMask);

        if (hit.collider != null)
        {

        }
    }

    void CameraBob()
    {


        if (transform.localPosition.y >= .2f)
        {
            goUp = false;
        }
        if (transform.localPosition.y <= .1f)
        {
            goUp = true;
        }


        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            moving = true;
        }
        else if (!(Input.GetButton("Vertical") && Input.GetButton("Horizontal")))
        {
            moving = false;
            goUp = false;
        }

        if (goUp)
        {
            if (moving)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, camUp, Time.deltaTime * 3);
            }
            else
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, startPos, Time.deltaTime * 7);
            }
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, startPos, Time.deltaTime * 3);
        }

    }
}
