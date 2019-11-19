using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpriteScript : MonoBehaviour
{
    SpriteRenderer SR;

    Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        Player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform.position);
    }
}
