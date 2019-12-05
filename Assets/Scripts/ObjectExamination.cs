using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectExamination : MonoBehaviour
{
    public static ObjectExamination me;
    public float distToInteractWithObj = 100f; // ray length
    public float distToTalk = 100f;
    public bool talking = false;
    public GameObject objBeingExamined;
    public Vector3 objOriginalPos;
    public Quaternion objOriginalRot;
    public float hRotSpd;
    public float vRotSpd;
    public float hAngle;
    public float vAngle;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        me = this;
    }

    // Update is called once per frame
    void Update()
    {
        
        // ray cast for obj examination
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit = new RaycastHit();
        Debug.DrawRay(mouseRay.origin,mouseRay.direction*distToInteractWithObj, Color.magenta);
        if (Physics.Raycast(mouseRay, out rayHit, distToInteractWithObj)){
            //print(rayHit.transform.tag);

            // when mouse on an interactable
            if (rayHit.transform.tag == "Interactable" && 
                !rayHit.transform.GetComponent<InteractableScript>().beingExamined && // if the object clicked is not being exmained
                !EmailManagerScript.me.checkingEmail) // if not checking email
            {
                CursorCtrlScript.me.cursorState = 3;
            }
            else if (rayHit.transform.tag == "laptop" && // when mouse on laptop
                !EmailManagerScript.me.checkingEmail) // if not checking email
            {
                CursorCtrlScript.me.cursorState = 1;
            }
            else
            {
                CursorCtrlScript.me.cursorState = 0;
            }

            if (Input.GetMouseButtonDown(0) && 
                objBeingExamined != null &&
                rayHit.transform.tag == "Untagged"
                )
            {
                objBeingExamined.GetComponent<InteractableScript>().beingExamined = false;
                objBeingExamined.GetComponent<InteractableScript>().destination = objOriginalPos;
                objBeingExamined.GetComponent<InteractableScript>().rDestination = objOriginalRot;
                TextManager.me.ChangeText(TextManager.me.defaultText);

                player.GetComponent<PlayerScript>().enabled = true;
                player.GetComponent<CharacterController>().enabled = true;
                this.gameObject.GetComponent<CameraScript>().enabled = true;

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                CursorCtrlScript.me.canMove = false;
            }
            // when clicking on an interactable
            if (rayHit.transform.tag == "Interactable" &&  // if mouse on an interactable
            Input.GetMouseButtonDown(0) && // if clicked
            !rayHit.transform.GetComponent<InteractableScript>().beingExamined && // if the object clicked is not being exmained
            !EmailManagerScript.me.checkingEmail) // if not checking email
            {
                objBeingExamined = rayHit.transform.gameObject;
                objOriginalPos = rayHit.transform.position;
                objOriginalRot = rayHit.transform.rotation;
                rayHit.transform.GetComponent<InteractableScript>().beingExamined = true;

                TextManager.me.ChangeText(rayHit.transform.GetComponent<InteractableScript>().objText);

                // freeze player action and camera
                player.GetComponent<PlayerScript>().enabled = false;
                player.GetComponent<CharacterController>().enabled = false;
                this.gameObject.GetComponent<CameraScript>().enabled = false;

                CursorCtrlScript.me.startMousePos = Input.mousePosition; // record start mouse position
                CursorCtrlScript.me.startPos = CursorCtrlScript.me.transform.position; // record start cursor position
                Cursor.lockState = CursorLockMode.None; // stop locking the cursor
                Cursor.visible = false; // hide the cursor
                CursorCtrlScript.me.canMove = true;
            }

            // if object is laptop
            if (rayHit.transform.tag == "laptop" && // if mouse on laptop
                Input.GetMouseButtonDown(0) && // if clicked
                !rayHit.transform.GetComponent<EmailManagerScript>().checkingEmail) // if not already checking email
            {
                EmailManagerScript.me.checkingEmail = true;

                // freeze player action and camera
                player.GetComponent<PlayerScript>().enabled = false;
                player.GetComponent<CharacterController>().enabled = false;
                this.gameObject.GetComponent<CameraScript>().enabled = false;

                // set up cursor
                CursorCtrlScript.me.startMousePos = Input.mousePosition; // record start mouse position
                CursorCtrlScript.me.startPos = CursorCtrlScript.me.transform.position; // record start cursor position
                Cursor.lockState = CursorLockMode.None; // stop locking the cursor
                Cursor.visible = false; // hide the cursor
                CursorCtrlScript.me.canMove = true;

                // display interface
                EmailManagerScript.me.emailInterface.SetActive(true);
            }
        }

        // put back object and default the text when clicking outside the object being examined
        else if (Input.GetMouseButtonDown(0) && objBeingExamined != null){
            objBeingExamined.GetComponent<InteractableScript>().beingExamined = false;
            objBeingExamined.GetComponent<InteractableScript>().destination = objOriginalPos;
            objBeingExamined.GetComponent<InteractableScript>().rDestination = objOriginalRot;
            TextManager.me.ChangeText(TextManager.me.defaultText);

            // unfreeze cam
            FreeMode();
        }

        // ray cast for talking
        Ray talkRay = new Ray(transform.position,transform.forward);
        RaycastHit characterHit = new RaycastHit();
        Debug.DrawRay(talkRay.origin, talkRay.direction*distToTalk, Color.cyan);
        
        if (Physics.Raycast(talkRay,out characterHit, distToTalk)){ // if player in front of the character
            if (!talking && (characterHit.transform.tag == "Character" || characterHit.transform.tag == "Quaft's door"))
            {
                CursorCtrlScript.me.cursorState = 2;
            }
            if (Input.GetMouseButtonDown(0) && // if click on a character
                characterHit.transform.tag == "Character" &&
                TextManager.me.convoState == 0)
            {
                talking = true;
                TextManager.me.convoState = 1;
                //TextManager.me.conversation = true;
                TextManager.me.characterURTalkingTo = characterHit.transform.gameObject;
            }
            if (Input.GetMouseButtonDown(0) && // if click on Quaft's door
                characterHit.transform.tag == "Quaft's door" &&
                QuaftsDoorScript.me.quaftState == 0)
            {
                QuaftsDoorScript.me.quaftState = 1;

                FocusMode();
            }
        }
        
        if ((!Physics.Raycast(talkRay,out characterHit, distToTalk) || // if the raycast for talking hit nothing
                characterHit.transform.tag == "Untagged") ||  // or if the raycast for talking hit noone
                (!Physics.Raycast(mouseRay, out rayHit, distToInteractWithObj) || // if the raycast for examination hit nothing
                rayHit.transform.tag == "Untagged") && // or if the raycast for examination hit objects that can't be interacted with
                objBeingExamined == null)
        {
            print("default");
            TextManager.me.convoState = 0;
            TextManager.me.ChangeText(TextManager.me.defaultText);
            CursorCtrlScript.me.cursorState = 0;

        }
        print("characterhit: " + characterHit.transform.tag);
        print("rayhit: " + rayHit.transform.tag);
    }

    public void FocusMode()
    {
        // freeze player action and camera and set up cursor movement
        player.GetComponent<PlayerScript>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;
        this.gameObject.GetComponent<CameraScript>().enabled = false;

        CursorCtrlScript.me.startMousePos = Input.mousePosition; // record start mouse position
        CursorCtrlScript.me.startPos = CursorCtrlScript.me.transform.position; // record start cursor position
        Cursor.lockState = CursorLockMode.None; // stop locking the cursor
        Cursor.visible = false; // hide the cursor
        CursorCtrlScript.me.canMove = true;
    }

    public void FreeMode()
    {
        // unfreeze player and camera
        player.GetComponent<PlayerScript>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;
        this.gameObject.GetComponent<CameraScript>().enabled = true;

        // lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        CursorCtrlScript.me.canMove = false;
        TextManager.me.ChangeText(TextManager.me.defaultText);
    }
}