using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TPlayer : MonoBehaviour
{
    int swc;
    public GameManager Gm;
    public GameObject Ant, Panel;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartTuto", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 10 && swc == 0)
        {
            swc = 1;
            Gm.inpTalk(111, 114);
            Instantiate(Ant, new Vector3(-2, 29, 0), Quaternion.Euler(0, 0, 0));
        }
        if(Gm.Kills == 1 && swc == 1)
        {
            swc = 2;
            Gm.inpTalk(121, 124);
        }
        if(Gm.min == 136)
        {
            Panel.GetComponent<Animator>().SetTrigger("Scene");
            Invoke("next", 2);
        }
        if (transform.position.x < -17.5f) transform.position = new Vector3(-17.5f, transform.position.y, 0);
        if (transform.position.x > 17.5f) transform.position = new Vector3(17.5f, transform.position.y, 0);
        if (transform.position.y < -10) transform.position = new Vector3(transform.position.x, -10, 0);
        if (transform.position.y > 47) transform.position = new Vector3(transform.position.x, 47, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "lab"&& swc == 2)
        {
            Gm.inpTalk(131, 135);
            swc = 3;
        }
    }
    void StartTuto()
    {
        swc = 0;
        Gm.inpTalk(101, 104);
    }

    void next()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
