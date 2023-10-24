using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    public GameObject exitButton;
    public Sprite clickButton, nonClickButton;

    private void OnMouseDrag()
    {
        exitButton.GetComponent<SpriteRenderer>().sprite = clickButton;
    }

    private void OnMouseUp()
    {
        exitButton.GetComponent<SpriteRenderer>().sprite = nonClickButton;
        Application.Quit();
    }
}
