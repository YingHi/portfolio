using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExplain : MonoBehaviour
{
    public GameObject explainButton, explain;
    public Sprite clickButton, nonClickButton;

    void Start()
    {
        explain.SetActive(false);
    }

    private void OnMouseDrag()
    {
        explainButton.GetComponent<SpriteRenderer>().sprite = clickButton;
    }

    private void OnMouseUp()
    {
        explainButton.GetComponent<SpriteRenderer>().sprite = nonClickButton;
        explain.SetActive(true);
    }
}
