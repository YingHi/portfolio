using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public float skillcoolTime;
    float angle;
    public GameObject left, right;
    Transform target;
    public EnemyManager Em;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if(Em.HP > 0)
        {
            angle = GetAngle(target.position);
            if (angle > -180 && angle < 0)
            {

                right.SetActive(true);
                left.GetComponent<Animator>().SetTrigger("Walk");
                left.SetActive(false);

            }
            else
            {
                left.SetActive(true);
                right.GetComponent<Animator>().SetTrigger("Walk");
                right.SetActive(false);
            }

            skillcoolTime -= Time.deltaTime;
            if (skillcoolTime < 0)
            {
                if (Vector2.Distance(target.transform.position, this.transform.position) <= 8f)
                {
                    if (left.activeSelf == true)
                    {
                        left.GetComponent<Animator>().SetTrigger("Skill");
                        skillcoolTime = 6f;
                    }
                    if (right.activeSelf == true)
                    {
                        right.GetComponent<Animator>().SetTrigger("Skill");
                        skillcoolTime = 6f;
                    }
                }
            }
        }
        
    }


    float GetAngle(Vector2 pos) // 각도 계산하는 함수
    {
        Vector2 Result = pos - new Vector2(transform.position.x, transform.position.y);
        float Angle = Mathf.Atan2(Result.y, Result.x) * Mathf.Rad2Deg;
        Angle += -90f;
        return Angle;
    }
}
