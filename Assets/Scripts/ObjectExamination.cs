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
            if(rayHit.transform.tag == "Interactable" && Input.GetMouseButtonDown(0) && !rayHit.transform.GetComponent<InteractableScript>().beingExamined){ // when clicking on an interactable
                objBeingExamined = rayHit.transform.gameObject;
                objOriginalPos = rayHit.transform.position;
                objOriginalRot = rayHit.transform.rotation;
                rayHit.transform.GetComponent<InteractableScript>().beingExamined = true;

                TextManager.me.ChangeText(rayHit.transform.GetComponent<InteractableScript>().objText);
            }
        }

        // put back object and default the text when clicking outside the object being examined
        else if (Input.GetMouseButtonDown(0) && objBeingExamined != null){
                objBeingExamined.GetComponent<InteractableScript>().beingExamined = false;
                objBeingExamined.GetComponent<InteractableScript>().destination = objOriginalPos;
                objBeingExamined.GetComponent<InteractableScript>().rDestination = objOriginalRot;
                TextManager.me.ChangeText(TextManager.me.defaultText);
        }

        // ray cast for talking
        Ray talkRay = new Ray(transform.position,transform.forward);
        RaycastHit characterHit = new RaycastHit();
        Debug.DrawRay(talkRay.origin, talkRay.direction*distToTalk, Color.cyan);
        if (Physics.Raycast(talkRay,out characterHit, distToTalk)){ // if player in front of the character
            if (!talking && characterHit.transform.tag == "Character"){
                TextManager.me.ChangeText(TextManager.me.conversationText); // show prompt if not talking
            }
            if (Input.GetKeyDown(KeyCode.E) && characterHit.transform.tag == "Character"){ // if player press E
                talking = true;
                TextManager.me.conversation = true;
                TextManager.me.characterURTalkingTo = characterHit.transform.gameObject;
            }
        }
        else if (!Physics.Raycast(talkRay,out characterHit, distToTalk) && 
                !Physics.Raycast(mouseRay, out rayHit, distToInteractWithObj) &&
                objBeingExamined == null){
            TextManager.me.ChangeText(TextManager.me.defaultText);
        }
    }
}