using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EmailManagerScript : MonoBehaviour
{
    // setting it up as a singleton
    public static EmailManagerScript me;

    // for sending email
    public PersonScriptableObject receiver;
    public PersonScriptableObject zara;
    public bool checkingEmail = false;
    public GameObject sendButton;
    public GameObject emailInterface;
    public GameObject ZaraButton;
    public GameObject player;
    public GameObject cam;
    public GameObject closeButton;

    // for receiving email
    public GameObject inbox;
    public GameObject emailContent;
    
    // Start is called before the first frame update
    void Start()
    {
        me = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendToZara()
    {
        receiver = zara;

        //print(receiver);
        sendButton.SetActive(true);
        emailContent.GetComponent<TextMeshProUGUI>().text = receiver.emailContent;

    }

    public void SendEmail()
    {
        //print("email sent");
        inbox.SetActive(true);
        
    }

    public void CloseEmail()
    {
        emailInterface.SetActive(false);
        checkingEmail = false;
        ZaraButton.SetActive(false);
        sendButton.SetActive(false);

        checkingEmail = false;

        // unfreeze player action and camera
        player.GetComponent<PlayerScript>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;
        cam.GetComponent<CameraScript>().enabled = true;

        // set up cursor
        //CursorCtrlScript.me.startMousePos = Input.mousePosition; // record start mouse position
        //CursorCtrlScript.me.startPos = CursorCtrlScript.me.transform.position; // record start cursor position
        Cursor.lockState = CursorLockMode.Locked; // stop locking the cursor
        Cursor.visible = false; // hide the cursor
        CursorCtrlScript.me.canMove = false;
    }

    public void CloseInbox()
    {
        inbox.SetActive(false);
        sendButton.SetActive(false);
        emailContent.GetComponent<TextMeshProUGUI>().text = "";
    }

}
