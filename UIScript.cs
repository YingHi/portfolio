using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public Sprite res, con, info;
    public GameManager gm;
    public GameObject Obj, UI, Circle, nope;

    public void cancel()
    {
        UI.SetActive(false);
    }

    public void build(Sprite A)
    {
        if (12500000 < gm.Money)
        {
            gm.Money -= 12500000;
            Obj.GetComponent<SpriteRenderer>().sprite = A;
            Obj.SetActive(true);
            UI.SetActive(false);
            Circle.SetActive(false);
        }
        else
        {
            nope.GetComponent<Animator>().SetTrigger("Trigger");
        }
    }

    public void conB()
    {
        if (12500000 < gm.Money)
        {
            build(con);
            gm.mad = false;
        }
        else
        {
            nope.GetComponent<Animator>().SetTrigger("Trigger");
        }
    }
    public void infoB()
    {
        if (12500000 < gm.Money)
        {
            build(info);
            gm.needfix = false;
        }
        else
        {
            nope.GetComponent<Animator>().SetTrigger("Trigger");
        }
    }
    public void resB()
    {
        if (12500000 < gm.Money)
        {
            build(res);
            gm.rest();
        }
        else
        {
            nope.GetComponent<Animator>().SetTrigger("Trigger");
        }
    }
}
