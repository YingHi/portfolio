using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSkill : MonoBehaviour
{
    float cooltime;
    public GameObject web;
    public Transform atkpoint;

    void Start()
    {
        cooltime = 3;
    }

    void Update()
    {
        if (cooltime <= 0)
        {
            Web();
            cooltime = 3;
        }
        else
        {
            cooltime -= Time.deltaTime;
        }
    }

    void Web()
    {
        GameObject B = Instantiate(web, atkpoint.position, Quaternion.Euler(0, 0, 0));
    }
}
