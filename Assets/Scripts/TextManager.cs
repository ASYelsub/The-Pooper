using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public static TextManager me;
    private string textToBeDisplayed;
    public string defaultText;
    public TextMeshProUGUI UGUI;

    // Start is called before the first frame update
    void Start()
    {
        me = this;
        textToBeDisplayed = defaultText;
    }

    // Update is called once per frame
    void Update()
    {
        UGUI.text = textToBeDisplayed;
    }

    public void ChangeText(string text){
        textToBeDisplayed = text;
    }
}
