using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{
    public AudioClip defaultS, bossS;
    AudioSource audiosource;
    public Timer Tm;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Tm.active == 0)
        {
            if (audiosource.clip == bossS)
            {
                audiosource.clip = defaultS;
                audiosource.Play();
            }
        }
        else
        {
            if (audiosource.clip == defaultS)
            {
                audiosource.clip = bossS;
                audiosource.Play();
            }
        }
    }
}
