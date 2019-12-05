﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public static TextManager me;
    public string textToBeDisplayed;
    public string defaultText;
    public string convoPromptText;
    public bool conversation;
    public GameObject characterURTalkingTo;
    public TextMeshProUGUI UGUI;
    private int index=-1;

    [TextArea]
    public string QuaftText1;
    [TextArea]
    public string QuaftText2;
    

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

        if(conversation){
            
            if (Input.GetMouseButtonDown(0)){
                if (index < characterURTalkingTo.GetComponent<CharacterScript>().text.Length){
                    index++;
                }
                if (index == characterURTalkingTo.GetComponent<CharacterScript>().text.Length){
                    conversation = false;
                    ObjectExamination.me.talking = false;
                    index = 0;
                }
            }
            textToBeDisplayed = characterURTalkingTo.GetComponent<CharacterScript>().text[index];
        }
    }

    public void ChangeText(string text){
        textToBeDisplayed = text;
    }
}
