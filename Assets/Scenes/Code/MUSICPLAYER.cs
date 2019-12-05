using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUSICPLAYER : MonoBehaviour
{

    AudioSource AS;
    public AudioClip SONG;

    // Start is called before the first frame update
    void Start()
    {
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
