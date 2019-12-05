using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpriteScript : MonoBehaviour
{
    SpriteRenderer SR;

    Transform Player;

    public Color[] charColors;
    public Sprite[] charSprites;

    public string Name;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        Player = GameObject.Find("Player").transform;
        ColorAssigner();
    }

    void ColorAssigner()
    {
        if (Name == "QUAFT")
        {
            Debug.Log("QUAFT!");
            SR.color = charColors[0];
            SR.sprite = charSprites[0];
        }
        else if (Name == "ZARA")
        {
            SR.color = charColors[1];
            SR.sprite = charSprites[1];
        }
        else if (Name == "ELIKENE")
        {
            SR.color = charColors[2];
            SR.sprite = charSprites[2];
        }
        else if (Name == "ISHA")
        {
            SR.color = charColors[3];
            SR.sprite = charSprites[3];
        }
        else if (Name == "CARLA")
        {
            SR.color = charColors[4];
            SR.sprite = charSprites[4];
        }
        else if (Name == "HELEN")
        {
            SR.color = charColors[5];
            SR.sprite = charSprites[5];
        }
        else if (Name == "CANDY")
        {
            SR.color = charColors[6];
            SR.sprite = charSprites[6];
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform.position);
    }
}
