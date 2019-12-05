using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class introConversationsScript : MonoBehaviour
{
    //USAGE: put it on a game manager game object
    public GameObject player; // reference for the player

    [TextArea]
    public string[] dialogue; // text to be displayed
    public int index = 0; // index to show text

    public bool canMove = false; // if player can move around

    // Start is called before the first frame update

    private void Awake()
    {
        
    }
    void Start()
    {
        TextManager.me.intro = true;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (TextManager.me.intro)
        {
            TextManager.me.ChangeText(dialogue[index]);
        }


        if (Input.GetMouseButtonDown(0) &&
            index < dialogue.Length)
        {
            index++;
        }

        if (Input.GetMouseButtonDown(0) &&
            index == dialogue.Length)
        {
            canMove = true;
            
        }

        if (!canMove)
        {
            player.GetComponent<PlayerScript>().enabled = false;
            player.GetComponent<CharacterController>().enabled = false;
        }
    }
}
