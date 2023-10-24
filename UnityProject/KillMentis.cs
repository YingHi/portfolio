using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMentis : MonoBehaviour
{
    public EnemyManager Mentis;
    int asked;
    GameObject Timer;

    // Start is called before the first frame update
    void Start()
    {
        asked = 0;
        Timer = GameObject.Find("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        if (Mentis.die == 1 && asked == 0)
        {
            this.GetComponent<Animator>().SetInteger("is_Die", 1);
            asked = 1;
        }
    }

    void Die()
    {
        Mentis.Die();
        Timer.GetComponent<Timer>().active -= 1;
    }
}
