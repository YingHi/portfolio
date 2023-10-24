using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill : MonoBehaviour
{
    public Transform RedZone;
    public GameObject Gm;

    private void Start()
    {
        Gm = GameObject.Find("GameManager");
    }
    public void active()
    {
        Collider2D[] collider2d = Physics2D.OverlapBoxAll(RedZone.position, new Vector2(5, 6), 0);
        foreach (Collider2D c2d in collider2d)
        {
            if (c2d.tag == "Player")
            {
                Gm.GetComponent<GameManager>().GetDmg(30);
            }
        }
    }
}
