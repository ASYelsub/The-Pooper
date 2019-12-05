using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOORSCRIPT : MonoBehaviour
{
    public bool doorToggle = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            doorToggle = !doorToggle;
        }

        if (doorToggle)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * 10);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 10);
        }


    }
}
