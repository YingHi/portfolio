using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Animator animator; //�ִϸ�����
    Transform target; //�÷��̾�

    public int atk; //���ݷ�
    public float moveSpeed; //���ǵ�

    public float skillcoolTime; //�ִϸ����� ��ų ��Ÿ��

    //fast �Լ�
    public float coolTime; //��Ÿ��
    public float sustainmentTime; //���ӽð�

    //atkSturn �Լ�
    public float atkcoolTime; //��Ÿ��
    public float atksustainmentTime; //���� �ð�
    public static bool sturn; //���� 
    public static float sturnTime = 2; //player��ũ��Ʈ���� ����. ���ϰɸ��� �ð�

    public static float HP = 100; //ü��

    public GameObject denger; //���� �����϶� ��� ���

    void Start()
    {
        denger.SetActive(false);
        sturn = false;

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        FollowTarget(); //�÷��̾� ���󰡴� �Լ�
        Fast(); //�����ð� ������ ���ǵ� �������� �Լ�
        atkSturn(); //�����ð� ������ ���ϵǴ� �Լ�

        //��Ÿ� �ȿ� ������ ��ų���°�
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

    void FollowTarget() //�÷��̾� ���󰡴� �Լ�
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    void Fast() //�����ð��Ǹ� ���ǵ� �������� �Լ�
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

    void atkSturn() //�����ð� ������ ���ϵǴ� �Լ�
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

    private void OnTriggerEnter2D(Collider2D collision) //�÷��̾�� �����ϸ� ����
    {
        //Player.HP -= atk;
        //Debug.Log(Player.HP);
    }
}
