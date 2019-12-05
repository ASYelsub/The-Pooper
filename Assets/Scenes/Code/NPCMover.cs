using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMover : MonoBehaviour
{
    public Transform[] NPCpoints;
    public Transform[] NPCpointsStageOne;

    CharacterController cc;

    float NPCspeed = 2;

    int TargetPos = 0   ;

    bool reachedPoint = false;
    bool moving = true;

    int RandomSec;

    public Vector3 startingPosition;
    Vector3 stageOnePosition;

    private void Awake()
    {
        //stageOnePosition = GetComponentInParent<Transform>().position;
    }

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();

        //cc.detectCollisions = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameStageDetector();
        //Movement();
    }

    void GameStageDetector()
    {
        if (GameStageManager.GameStage == 0)
        {
            if (GameStageManager.robertaLeft)
            {
                cc.enabled = true;
                Movement();
            }
            else
            {
                cc.enabled = false;
                transform.position = startingPosition;
            }
        }
        else if (GameStageManager.GameStage == 1)
        {
            //transform.position = GetComponentInParent<Transform>().position;
            Movement2();
        }
    }

    void Movement()
    {
        transform.LookAt(NPCpoints[TargetPos]);
        cc.Move(transform.forward * NPCspeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);

        if (Mathf.Round(transform.position.x) == Mathf.Round(NPCpoints[TargetPos].position.x)&&
            Mathf.Round(transform.position.y) == Mathf.Round(NPCpoints[TargetPos].position.y)&&
            Mathf.Round(transform.position.z) == Mathf.Round(NPCpoints[TargetPos].position.z)&&
            TargetPos < 2)
        {
            TargetPos++;
        }

        //set it to increment target pos after the position is reached
    }
    void Movement2()
    {
        transform.LookAt(NPCpointsStageOne[TargetPos]);
        cc.Move(transform.forward * NPCspeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);

        if (Mathf.Round(transform.position.x) == Mathf.Round(NPCpointsStageOne[TargetPos].position.x) &&
            Mathf.Round(transform.position.y) == Mathf.Round(NPCpointsStageOne[TargetPos].position.y) &&
            Mathf.Round(transform.position.z) == Mathf.Round(NPCpointsStageOne[TargetPos].position.z) &&
            TargetPos > 0)
        {
            TargetPos--;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (Transform trans in NPCpoints)
        {
            Gizmos.DrawWireSphere(trans.position, .15f);
        }
        Gizmos.color = Color.cyan;
        foreach (Transform trans in NPCpointsStageOne)
        {
            Gizmos.DrawWireSphere(trans.position, .15f);
        }

    }
}
