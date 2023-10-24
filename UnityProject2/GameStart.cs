using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject startButton;
    public Sprite clickButton, nonClickButton;

    private void OnMouseDrag()
    {
        startButton.GetComponent<SpriteRenderer>().sprite = clickButton;
    }

    private void OnMouseUp()
    {
        startButton.GetComponent<SpriteRenderer>().sprite = nonClickButton;
        SceneManager.LoadScene("SampleScene");
    }
}
