using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScript : MonoBehaviour
{
    [Header("FOR OBJECT EXAMINATION")]
    public Vector3 destination; // position to move
    public Quaternion rDestination; // rotation to rotate
    public Transform examinationPos;
    public bool beingExamined = false;
    public float objectSpd;
    public ObjectExamination objManager;
    public float hRotSpd;
    public float vRotSpd;
    public float hAngle;
    public float vAngle;

    [Header("FOR TEXT")]
    public string objText;
    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
        rDestination = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // move object
        transform.position = Vector3.Lerp(transform.position,destination,objectSpd * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation,rDestination,objectSpd * Time.deltaTime);

        // when being examined
        if (beingExamined){
            destination = examinationPos.position;
            if (Input.GetMouseButton(1)){ // when holding right key of mouse, let player rotate object

            float mouseX = Input.GetAxis("Mouse X"); // horizontal mouse velocity
            float mouseY = Input.GetAxis("Mouse Y"); // vertical mouse velocity

            vAngle += mouseY * vRotSpd * Time.deltaTime;
            hAngle -= mouseX * hRotSpd * Time.deltaTime;

            transform.localEulerAngles = new Vector3(vAngle,hAngle,0f); // rotate object
        }
        }
    }
}
