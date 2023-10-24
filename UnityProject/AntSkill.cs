using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSkill : MonoBehaviour
{
    public EnemyManager Em;
    float coolTime, sustainmentTime, defaultspeed;
    // Start is called before the first frame update
    void Start()
    {
        defaultspeed = Em.moveSpeed;
        sustainmentTime = 3.0f;
        coolTime = 5.0f;
    }

    void Fast() //�����ð��Ǹ� ���ǵ� �������� �Լ�
    {
        coolTime -= Time.deltaTime;
        if (coolTime < 0)
        {
            sustainmentTime -= Time.deltaTime;
            if (sustainmentTime > 0)
            {
                Em.moveSpeed = defaultspeed * 2;
            }
        }
        if (sustainmentTime < 0)
        {
            Em.moveSpeed = defaultspeed;
            coolTime = 5.0f;
            sustainmentTime = 3.0f;
        }
    }
}
