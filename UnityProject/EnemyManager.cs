using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    GameObject Gm; // 게임 매니저
    public int atk; //공격력
    Transform target;
    public int die;
    public float HP;
    public float moveSpeed; //스피드
    float stunTime;
    public int elite;
    public GameObject bullet, redbullet;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        die = 0;
        Gm = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            if(die == 0)
            {
                this.GetComponent<Animator>().SetInteger("is_Die",1);
                die = 1;
            }
            
        }
        else
        {
            if (stunTime <= 0)
            {
                FollowTarget();
            }
            else
            {
                stunTime -= Time.deltaTime;
            }
        }
    }
    void FollowTarget() //플레이어 따라가는 함수
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        float angle = GetAngle(target.position);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    float GetAngle(Vector2 pos) // 각도 계산하는 함수
    {
        Vector2 Result = pos - new Vector2(transform.position.x, transform.position.y);
        float Angle = Mathf.Atan2(Result.y, Result.x) * Mathf.Rad2Deg;
        Angle += -90f;
        return Angle;
    }

    public void Stun(float St)
    {
        stunTime = St;
    }

    public void Die()
    {
        Gm.GetComponent<GameManager>().deadEnemy();
        if(elite == 1)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 0));
            Vector3 B = new Vector3(transform.position.x + 1, transform.position.y, 0);
            Instantiate(redbullet, B, Quaternion.Euler(0, 0, 0));
        }
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Gm.GetComponent<GameManager>().GetDmg(atk);
        }
    }
}
