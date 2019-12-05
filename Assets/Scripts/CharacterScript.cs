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
        text = new string[2];
        info = GetComponentInChildren<NPCSpriteScript>();
        name = info.Name;

        text[1] = name + ": my name is " + name;
        text[0] = "Roberta: Who are you?";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
