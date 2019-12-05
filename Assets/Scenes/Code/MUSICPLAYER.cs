using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUSICPLAYER : MonoBehaviour
{

    public static AudioSource AS;
    public AudioClip SONG;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        AS = GetComponent<AudioSource>();
        AS.PlayOneShot(SONG);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!AS.isPlaying)
        {
            AS.PlayOneShot(SONG);
        }
    }
}
