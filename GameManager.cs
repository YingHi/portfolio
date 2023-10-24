using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject plane;
    public double ToMoney, showMoney;
    public TextMeshProUGUI txt;
    public float Timer, Money;
    public bool mad, needfix;

    private void Start()
    {
        Money = 0;
        Timer = 0;
        ToMoney = 900000000;
        mad = true;
        needfix = true;
    }

    void Update()
    {
        showMoney = Money;
        MovePlane();
        txt.text = "현재 금액 : " + showMoney + "\n목표 금액 : " + ToMoney;
        Timer += Time.deltaTime;
        if (Money > ToMoney)
        {
            PlayerPrefs.SetFloat("Timer",Timer);
            PlayerPrefs.SetFloat("Money", Money);
            SceneManager.LoadScene("GameOver");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void MovePlane()
    {
        plane.transform.Translate(new Vector2(-1, 0.5f) * Time.deltaTime);
        if (plane.transform.position.x <= 0) plane.transform.position = new Vector2(23.0f, 4.0f);
    }
    public void addMoney(int a)
    {
        Money += a;
    }

    public void getMoney()
    {
        Money += 300000;
    }

    public void rest()
    {
        InvokeRepeating("getMoney", 5, 5);
    }
}
