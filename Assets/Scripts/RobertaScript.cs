using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RobertaScript : MonoBehaviour
{
    public Outline startOutline;
    public Image background;
    public GameObject roberta;
    public void ChangeScene()
    {
        background.GetComponent<Image>().color = new Color(0,0,0);
        roberta.SetActive(false);
    }
    public void OutLine(int outLineNumber)
    {
        if(outLineNumber == 0)
        {
            startOutline.GetComponent<Outline>().enabled = true;
        }
        if(outLineNumber == 1)
        {
            startOutline.GetComponent<Outline>().enabled = false;
        }
    }
}
