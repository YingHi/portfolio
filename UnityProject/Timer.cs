using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameManager Gm;
    public float timer;
    Text text;
    public int hour, minute, active;
    // Start is called before the first frame update
    void Start()
    {
        timer = 240f;
        text = GetComponent<Text>();
        active = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimeRun();
        makeRound();
    }

    void TimeRun()
    {
        if(active == 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0) timer = 0;
            hour = (int)timer / 60;
            minute = (int)timer % 60;
            text.text = hour + " : " + minute;
        }
        
    }

    void makeRound()
    {
        if (timer < 120 && Gm.Round == 1) Gm.setRound(2);
        if (timer == 0 && Gm.Round == 2)
        {
            Gm.setRound(3);
            active = 1;
            timer = 1;
        }
        if (timer == 0 && Gm.Round == 3) Gm.setRound(4);
        if (timer == 0 && Gm.Round == 4) timer = 360;
        if (timer < 180 && Gm.Round == 4) {
            Gm.setRound(5);
            active = 1;
        }
        if(timer <= 60 && Gm.Round == 5)
        {
            Gm.setRound(6);
            active = 2;
        }
        if (timer == 0 && Gm.Round == 6) Gm.setRound(7);

    }
}
