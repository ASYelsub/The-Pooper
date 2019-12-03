using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMPChangeColorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        TextMeshProUGUI textmeshPro = GetComponent<TextMeshProUGUI>();
        textmeshPro.faceColor = new Color32(254,255,255,255); // don't know why but if put in 255,255,255,255 it won't generate a material to change the text color
    }
}
