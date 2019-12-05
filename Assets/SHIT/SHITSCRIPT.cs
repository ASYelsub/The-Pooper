using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHITSCRIPT : MonoBehaviour
{
    MeshRenderer MR;

    float r;
    float g;
    float b;

    int Stage;

    void Start()
    {
        Stage = 0;
        MR = GetComponent<MeshRenderer>();
        r = 1;
        g = 0;
        b = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ColorShift();

        MR.material.color = new Color(r, g, b);

        transform.Rotate(0,Time.deltaTime * 180, 0);
    }

    void ColorShift()
    {
        if (r == 1 && g == 0 && b == 0)
        {
            Stage = 0;
        }
        if (r == 1 && g == 1 && b == 0)
        {
            Stage = 1;
        }
        if (r == 0 && g == 1 && b == 0)
        {
            Stage = 2;
        }
        if (r == 0 && g == 1 && b == 1)
        {
            Stage = 3;
        }
        if (r == 0 && g == 0 && b == 1)
        {
            Stage = 4;
        }
        if (r == 1 && g == 0 && b == 1)
        {
            Stage = 5;
        }
        //change colors
        if (Stage == 0)
        {
            r += 0;
            g += Time.deltaTime;
            b += 0;
        }
        if (Stage == 1)
        {
            r += -Time.deltaTime;
            g += 0;
            b += 0;
        }
        if (Stage == 2)
        {
            r += 0;
            g += 0;
            b += Time.deltaTime;
        }
        if (Stage == 3)
        {
            r += 0;
            g += -Time.deltaTime;
            b += 0;
        }
        if (Stage == 4)
        {
            r += Time.deltaTime;
            g += 0;
            b += 0;
        }
        if (Stage == 5)
        {
            r += 0;
            g += 0;
            b += -Time.deltaTime;
        }


        r = Mathf.Clamp(r, 0, 1);
        g = Mathf.Clamp(g, 0, 1);
        b = Mathf.Clamp(b, 0, 1);


    }
}
