using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI timertext, moneytext;
    double A;
    int B;
    // Start is called before the first frame update
    void Start()
    {
        A = PlayerPrefs.GetFloat("Money");
        B = Mathf.FloorToInt(PlayerPrefs.GetFloat("Timer"));
        timertext.text = B + "sec";
        moneytext.text = A.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
