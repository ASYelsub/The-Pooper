using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    [TextArea]
    public string[] text;

    NPCSpriteScript info;
    string name;

    // Start is called before the first frame update
    void Start()
    {
        info = GetComponentInChildren<NPCSpriteScript>();
        name = info.Name;

        if (info.name == "ISHA")
        {
            text = new string[2];
        }
        else if (info.name == "")
        {
            text = new string[2];
        }
        else if (info.name == "ISHA")
        {
            text = new string[2];
        }
        else if (info.name == "ISHA")
        {
            text = new string[2];
        }
        else if (info.name == "ISHA")
        {
            text = new string[2];
        }
        else if (info.name == "ISHA")
        {
            text = new string[2];
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
