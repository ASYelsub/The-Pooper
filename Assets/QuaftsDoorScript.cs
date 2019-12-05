using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuaftsDoorScript : MonoBehaviour
{
    public static QuaftsDoorScript me;

    public GameObject yesButton;
    public GameObject noButton;
    public int quaftState;
    public string IdentifyScenesName;

    // Start is called before the first frame update
    void Start()
    {
        me = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (quaftState == 2) // identify state
        {
            yesButton.SetActive(false);
            noButton.SetActive(false);
            TextManager.me.ChangeText(TextManager.me.QuaftText2);
            if (Input.GetMouseButtonDown(0)) // if left clicked
            {
                SceneManager.LoadScene(IdentifyScenesName); // go to another scene
            }
        }

        if (quaftState == 1) // question state
        {
            yesButton.SetActive(true);
            noButton.SetActive(true);
            TextManager.me.ChangeText(TextManager.me.QuaftText1);
        }

        if (quaftState == 0) // default state
        {
            yesButton.SetActive(false);
            noButton.SetActive(false);
        }
    }

    public void endConvoWithQuaft()
    {
        //print("end convo");
        quaftState = 0; // default phase
        ObjectExamination.me.FreeMode();
    }

    public void Ready()
    {
        TextManager.me.ChangeText(TextManager.me.QuaftText2);
        //print("i'm ready");
        quaftState = 2;
    }
}
