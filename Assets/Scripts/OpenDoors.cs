using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit,Mathf.Infinity))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (hit.collider.tag == "Door")
                {
                    hit.collider.gameObject.GetComponentInParent<DOORSCRIPT>().doorToggle = !hit.collider.gameObject.GetComponentInParent<DOORSCRIPT>().doorToggle;
                }
            }
        }
    }
}
