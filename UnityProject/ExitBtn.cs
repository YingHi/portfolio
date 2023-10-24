using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitBtn : MonoBehaviour
{
    public Text txt;
    public AudioClip onMouse, Click;
    AudioSource audiosource;
    private void Start()
    {
        audiosource = gameObject.GetComponent<AudioSource>();
    }
    public void enter()
    {
        txt.GetComponent<Animator>().SetTrigger("a");
        audiosource.PlayOneShot(onMouse, 1);
    }

    public void outtt()
    {
        txt.GetComponent<Animator>().SetTrigger("b");
    }

    public void onclick()
    {
        audiosource.PlayOneShot(Click, 1);
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
