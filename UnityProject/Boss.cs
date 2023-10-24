using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Animator animator; //애니메이터
    Transform target; //플레이어

    public int atk; //공격력
    public float moveSpeed; //스피드

    public float skillcoolTime; //애니메이터 스킬 쿨타임

    //fast 함수
    public float coolTime; //쿨타임
    public float sustainmentTime; //지속시간

    //atkSturn 함수
    public float atkcoolTime; //쿨타임
    public float atksustainmentTime; //지속 시간
    public static bool sturn; //스턴 
    public static float sturnTime = 2; //player스크립트에서 쓰임. 스턴걸리는 시간

    public static float HP = 100; //체력

    public GameObject denger; //스턴 공격일때 경고 모양

    void Start()
    {
        denger.SetActive(false);
        sturn = false;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        FollowTarget(); //플레이어 따라가는 함수
        Fast(); //일정시간 지나면 스피드 빨라지는 함수
        atkSturn(); //일정시간 지나면 스턴되는 함수

        //사거리 안에 들어오면 스킬쓰는거
        skillcoolTime -= Time.deltaTime;
        if(skillcoolTime > 0)
        {
            if (Vector2.Distance(target.transform.position, this.transform.position) <= 5f)
            {
                //animator.SetTrigger("Skill");
            }
        }
        if (skillcoolTime <= 0) skillcoolTime = 6;
    }

    void FollowTarget() //플레이어 따라가는 함수
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    void Fast() //일정시간되면 스피드 빨라지는 함수
    {
        coolTime -= Time.deltaTime;
        if (coolTime < 0)
        {
            sustainmentTime -= Time.deltaTime;
            if (sustainmentTime > 0)
            {
                moveSpeed = 8.0f;
            }
        }
        if (sustainmentTime < 0)
        {
            moveSpeed = 3.0f;
            coolTime = 5.0f;
            sustainmentTime = 3.0f;
        }
    }

    void atkSturn() //일정시간 지나면 스턴되는 함수
    {
        atkcoolTime -= Time.deltaTime;
        if (atkcoolTime < 0)
        {
            atksustainmentTime -= Time.deltaTime;
            if (atksustainmentTime > 0)
            {
                sturn = true;
                denger.SetActive(true);
            }
        }
        if (atksustainmentTime < 0)
        {
            denger.SetActive(false);
            sturn = false;
            atkcoolTime = 3.0f;
            atksustainmentTime = 5.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //플레이어랑 접촉하면 공격
    {
        //Player.HP -= atk;
        //Debug.Log(Player.HP);
    }
}
