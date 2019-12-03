using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject playButton;
    public GameObject creditsButton;
    public GameObject play1Button;
    public GameObject thePooper;
    public GameObject directions;
    public Outline playOutline;
    public Outline creditsOutline;
    public AudioSource blip;

    public void Start()
    {
        playOutline.GetComponent<Outline>().enabled = false;
        creditsOutline.GetComponent<Outline>().enabled = false;
        playButton.SetActive(true);
        creditsButton.SetActive(true);
        play1Button.SetActive(false);
        thePooper.SetActive(true);
        directions.SetActive(false);
        playOutline.GetComponent<Outline>().enabled = false;
        creditsOutline.GetComponent<Outline>().enabled = false;
    }
    public void ChangeOutline(int outlineInt)
    {
        if(outlineInt == 0)
        {
            playOutline.GetComponent<Outline>().enabled = true;
            creditsOutline.GetComponent<Outline>().enabled = false;
            blip.Play();
        }
        if (outlineInt == 1)
        {
            playOutline.GetComponent<Outline>().enabled = false;
            creditsOutline.GetComponent<Outline>().enabled = true;
            blip.Play();
        }
        if (outlineInt == 2)
        {
            playOutline.GetComponent<Outline>().enabled = false;
            creditsOutline.GetComponent<Outline>().enabled = false;
        }

    }
    public void ButtonPress(int buttonInt)
    {
        if(buttonInt == 0)
        {
            Debug.Log("Play pressed");
            playButton.SetActive(false);
            creditsButton.SetActive(false);
            play1Button.SetActive(true);
            thePooper.SetActive(false);
            directions.SetActive(true);
            blip.Play();
        }
        if (buttonInt == 1)
        {
            Debug.Log("Credits pressed");
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(2);
    }
}
