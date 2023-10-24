using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartTxt : MonoBehaviour
{
    public Text txt, txt2;
    public GameObject Panel;
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

    public void gameStartBtn()
    {
        audiosource.PlayOneShot(Click, 1);
        Destroy(txt);
        Destroy(txt2);
        Panel.GetComponent<Animator>().SetTrigger("Scene");
        Invoke("changeScene", 2f);
    }

    void changeScene()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
