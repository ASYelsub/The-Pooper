using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject playButton;
    public GameObject creditsButton;
    public Outline playOutline;
    public Outline creditsOutline;

    public void Start()
    {
        playOutline.GetComponent<Outline>().enabled = false;
        creditsOutline.GetComponent<Outline>().enabled = false;
    }
    public void ChangeOutline(int outlineInt)
    {
        if(outlineInt == 0)
        {
            playOutline.GetComponent<Outline>().enabled = true;
            creditsOutline.GetComponent<Outline>().enabled = false;
        }
        if (outlineInt == 1)
        {
            playOutline.GetComponent<Outline>().enabled = false;
            creditsOutline.GetComponent<Outline>().enabled = true;
        }

    }
    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
