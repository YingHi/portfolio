using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web : MonoBehaviour
{
    float time;
    GameObject Gm;
    GameObject Player;
    int atk = 2;
    public int moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        time = 2;
        Player = GameObject.FindGameObjectWithTag("Player");
        Gm = GameObject.Find("GameManager");
        FollowTarget();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            Destroy(this.gameObject);
        }
        transform.Translate(new Vector2(0, moveSpeed)*Time.deltaTime);
    }

    void FollowTarget() //플레이어 따라가는 함수
    {
        float angle = GetAngle(Player.transform.position);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    float GetAngle(Vector2 pos) // 각도 계산하는 함수
    {
        Vector2 Result = pos - new Vector2(transform.position.x, transform.position.y);
        float Angle = Mathf.Atan2(Result.y, Result.x) * Mathf.Rad2Deg;
        Angle += -90f;
        return Angle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Gm.GetComponent<GameManager>().GetDmg(atk);
            Player.GetComponent<PlayerManager>().GetSlow();
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Ob"))
        {
            Destroy(this.gameObject);
        }
    }
}
