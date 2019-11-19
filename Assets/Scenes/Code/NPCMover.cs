using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMover : MonoBehaviour
{
    public Transform[] NPCpoints;

    CharacterController cc;

    float NPCspeed = 2;

    Vector3 TargetPos;

    bool reachedPoint = false;
    bool moving = true;

    int RandomSec;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        TargetPos = NPCpoints[Random.Range(0, 3)].position;
    }

    // Update is called once per frame
    void Update()
    {


        if (Mathf.Round(transform.position.x) == Mathf.Round(TargetPos.x) && Mathf.Round(transform.position.z) == Mathf.Round(TargetPos.z))
        {
            RandomSec = Random.Range(2,6);
            reachedPoint = true;
            TargetPos = NPCpoints[Random.Range(0, 3)].position;
        }
        else
        {
            reachedPoint = false;
        }

        if (reachedPoint)
        {
            moving = false;
        }

        if (!moving)
        {
            StartCoroutine("WaitAtPoint");
        }

        transform.LookAt(TargetPos);
        if (moving)
        {
            cc.Move(transform.forward * NPCspeed * Time.deltaTime);
        }
        transform.rotation = Quaternion.Euler(0,transform.rotation.y, 0);
    }

    IEnumerator WaitAtPoint()
    {
        yield return new WaitForSeconds(RandomSec);
        moving = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (Transform trans in NPCpoints)
        {
            Gizmos.DrawWireSphere(trans.position, .15f);
        }

    }
}
