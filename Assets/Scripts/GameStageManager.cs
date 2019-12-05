using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageManager : MonoBehaviour
{
    public static int GameStage = 0;
    public GameObject roof;
    public static bool robertaLeft = false;
    
    // Start is called before the first frame update
    void Start()
    {
        GameStage = 0;
        roof.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
