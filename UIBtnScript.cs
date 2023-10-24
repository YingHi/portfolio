using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBtnScript : MonoBehaviour
{
    public GameObject UI, Circle, Slider, ride, nope;
    public SliderScript sc;
    public GameManager gm;
    public void cancel()
    {
        UI.SetActive(false);
    }

    public void build()
    {
        if(sc.Bill < gm.Money)
        {
            gm.Money -= sc.Bill;
            Slider.SetActive(true);
            ride.SetActive(true);
            UI.SetActive(false);
            Circle.SetActive(false);
        }
        else
        {
            nope.GetComponent<Animator>().SetTrigger("Trigger");
        }
    }

}
