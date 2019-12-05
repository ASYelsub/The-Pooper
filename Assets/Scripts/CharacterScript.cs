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
            text = new string[12];
            text[0] = "";
            text[1] = "";
            text[2] = "";
            text[3] = "";
            text[4] = "";
            text[5] = "";
            text[6] = "";
            text[7] = "";
            text[8] = "";
            text[9] = "";
            text[10] = "";
            text[11] = "";
        }
        else if (info.name == "ZARA")
        {
            text = new string[11];
            text[0] = "";
            text[1] = "";
            text[2] = "";
            text[3] = "";
            text[4] = "";
            text[5] = "";
            text[6] = "";
            text[7] = "";
            text[8] = "";
            text[9] = "";
            text[10] = "";
        }
        else if (info.name == "CANDY")
        {
            text = new string[22];
            text[0] = "";
            text[1] = "";
            text[2] = "";
            text[3] = "";
            text[4] = "";
            text[5] = "";
            text[6] = "";
            text[7] = "";
            text[8] = "";
            text[9] = "";
            text[10] = "";
            text[11] = "";
            text[12] = "";
            text[13] = "";
            text[14] = "";
            text[15] = "";
            text[16] = "";
            text[17] = "";
            text[18] = "";
            text[19] = "";
            text[20] = "";
            text[21] = "";
        }
        else if (info.name == "HELEN")
        {
            text = new string[6];
            text[0] = "";
            text[1] = "";
            text[2] = "";
            text[3] = "";
            text[4] = "";
            text[5] = "";
        }
        else if (info.name == "CARLA")
        {
            text = new string[6];
            text[0] = "";
            text[1] = "";
            text[2] = "";
            text[3] = "";
            text[4] = "";
            text[5] = "";
        }
        else if (info.name == "ELIKENE")
        {
            text = new string[11];
            text[0] = "";
            text[1] = "";
            text[2] = "";
            text[3] = "";
            text[4] = "";
            text[5] = "";
            text[6] = "";
            text[7] = "";
            text[8] = "";
            text[9] = "";
            text[10] = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
