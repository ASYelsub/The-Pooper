using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaftsDoorScript : MonoBehaviour
{
    public static QuaftsDoorScript me;

    public GameObject yesButton;
    public GameObject noButton;
    public int quaftState;

    // Start is called before the first frame update
    void Start()
    {
        me = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (quaftState == 1) // question state
        {
            yesButton.SetActive(true);
            noButton.SetActive(true);
        }

        if (quaftState == 0)
        {
            yesButton.SetActive(false);
            noButton.SetActive(false);
        }
    }

    public void endConvoWithQuaft()
    {
        print("end convo");
        quaftState = 0; // default phase
        ObjectExamination.me.FreeMode();
    }

    public void Ready()
    {
        print("i'm ready");
    }
}
