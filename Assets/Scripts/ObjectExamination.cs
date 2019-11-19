using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectExamination : MonoBehaviour
{
    public float distToInteract = 100f; // ray length
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
        
    }

    // Update is called once per frame
    void Update()
    {
        // ray cast
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit = new RaycastHit();
        Debug.DrawRay(mouseRay.origin,mouseRay.direction*distToInteract, Color.magenta);
        if (Physics.Raycast(mouseRay, out rayHit, distToInteract)){
            if(rayHit.transform.tag == "Interactable" && Input.GetMouseButtonDown(0)){ // when clicking on an interactable
                objBeingExamined = rayHit.transform.gameObject;
                objOriginalPos = rayHit.transform.position;
                objOriginalRot = rayHit.transform.rotation;
                rayHit.transform.GetComponent<InteractableScript>().beingExamined = true;
            }
        }

        // put back object
        else if (Input.GetMouseButtonDown(0)){
                objBeingExamined.GetComponent<InteractableScript>().beingExamined = false;
                objBeingExamined.GetComponent<InteractableScript>().destination = objOriginalPos;
                objBeingExamined.GetComponent<InteractableScript>().rDestination = objOriginalRot;
            }
    }
}
