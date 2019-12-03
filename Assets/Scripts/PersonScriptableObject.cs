using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PersonScriptableObject : ScriptableObject
{
    public string name;
    [TextArea]
    public string emailContent;
}
