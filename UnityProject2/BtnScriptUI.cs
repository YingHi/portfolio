using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnScriptUI : MonoBehaviour
{
    public Sprite Push, Pull;
    public GameObject G;
    public void Pushh()
    {
        Invoke("Pulll", 0.05f);
    }
    public void Pulll()
    {
        G.GetComponent<SpriteRenderer>().sprite = Pull;
    }
}
