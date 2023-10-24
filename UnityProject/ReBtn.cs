using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReBtn : MonoBehaviour
{
    public Text txt;

    public void enter()
    {
        txt.GetComponent<Animator>().SetTrigger("a");
    }

    public void outtt()
    {
        txt.GetComponent<Animator>().SetTrigger("b");
    }

    public void onclick()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
