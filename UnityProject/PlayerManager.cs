using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameManager Gm;
    public GameObject left, right, front, back, leftA, rightA, frontA, backA, bullet, bulletR, rerall, LeftF, RightF, FrontF, BackF;
    public float speed, time;
    private Vector3 vector;
    public string dir;
    int atk, is_Die;
    public float reload;
    float slow, slowspeed;
    public GameObject slowimg;
    public AudioClip atkS, SatkS, re;
    AudioSource audiosource;

    void Start()
    {
        audiosource = gameObject.GetComponent<AudioSource>();
        dir = "Front";
        atk = 0;
        reload = 0;
        slow = 0;
        slowspeed = 0;
        is_Die = 0;
    }

    void Update()
    {
        if(Gm.HP > 0)
        {
            if (reload <= 0)
            {
                attack();
            }
            else if (reload == 1)
            {
                atk = 0;
                Invoke("Reload", 2);
                rerall.SetActive(true);
                reload = 2;
                FrontF.SetActive(false);
                BackF.SetActive(false);
                LeftF.SetActive(false);
                RightF.SetActive(false);
            }
            if (atk == 0)
            {
                moving();
                Ani();
            }
            SlowSys();
        }
        else
        {
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        if(is_Die == 0)
        {
            left.SetActive(true);
            right.SetActive(false);
            front.SetActive(false);
            back.SetActive(false);
            frontA.SetActive(false);
            backA.SetActive(false);
            leftA.SetActive(false);
            rightA.SetActive(false);
            left.GetComponent<Animator>().SetInteger("is_Die", 1);
            Invoke("GameOver", 1);
            is_Die = 1;
        }
    }

    void GameOver()
    {
        Gm.GameOver();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("item"))
        {
            Gm.HP += 25;
            if(Gm.HP > 100)
            {
                Gm.HP = 100;
            }
            collision.gameObject.GetComponent<Water>().Respawn();
        }
        if (collision.gameObject.CompareTag("yellow"))
        {
            Gm.MaxBullet += 15;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("red"))
        {
            Gm.RedBullet += 2;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "lab")
        {
            if (Gm.Phase == 3 && Gm.Round == 4)
            {
                Gm.inpTalk(151, 159);
                Gm.setRound(5);
            }
            if(Gm.Round == 7)
            {
                Gm.Round = 8;
                Gm.inpTalk(171, 177);
            }
            if(Gm.Round == 8)
            {
                if (Gm.min == 178)
                {
                    Gm.GameClear();
                }
            }
        }
    }

    void moving()
    {
        if (Gm.isTalk) { return; } else
        {
            vector.x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
            vector.y = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
            transform.position = new Vector2(transform.position.x + vector.x, transform.position.y + vector.y);
        }
    }

    void attack()
    {
        if (Gm.isTalk) { return; } else
        {
            if (Input.GetKey(KeyCode.Z))
            {
                if (atk == 0)
                {
                    if (Gm.Bullet >= 1)
                    {
                        audiosource.PlayOneShot(atkS, 1);
                        atkAni();
                        if (dir == "Front")
                        {
                            FrontF.SetActive(true);
                            frontA.GetComponent<Animator>().SetTrigger("Shoot");
                            Instantiate(bullet, FrontF.transform.position, Quaternion.Euler(0, 0, 180));
                        }
                        if (dir == "Back")
                        {
                            BackF.SetActive(true);
                            backA.GetComponent<Animator>().SetTrigger("Shoot");
                            Instantiate(bullet, BackF.transform.position, Quaternion.Euler(0, 0, 0));
                        }
                        if (dir == "Left")
                        {
                            LeftF.SetActive(true);
                            leftA.GetComponent<Animator>().SetTrigger("Shoot");
                            Instantiate(bullet, LeftF.transform.position, Quaternion.Euler(0, 0, 90));
                        }
                        if (dir == "Right")
                        {
                            RightF.SetActive(true);
                            rightA.GetComponent<Animator>().SetTrigger("Shoot");
                            Instantiate(bullet, RightF.transform.position, Quaternion.Euler(0, 0, 270));
                        }
                        atk = 1;
                        time = 0f;
                        Gm.Bullet -= 1;
                    }
                }
            }
            if (Input.GetKey(KeyCode.X))
            {
                if (atk == 0)
                {
                    if (Gm.RedBullet >= 1)
                    {
                        audiosource.PlayOneShot(SatkS, 1);
                        atkAni();
                        if (dir == "Front")
                        {
                            FrontF.SetActive(true);
                            frontA.GetComponent<Animator>().SetTrigger("Shoot");
                            Instantiate(bulletR, FrontF.transform.position, Quaternion.Euler(0, 0, 180));
                        }
                        if (dir == "Back")
                        {
                            BackF.SetActive(true);
                            backA.GetComponent<Animator>().SetTrigger("Shoot");
                            Instantiate(bulletR, BackF.transform.position, Quaternion.Euler(0, 0, 0));
                        }
                        if (dir == "Left")
                        {
                            LeftF.SetActive(true);
                            leftA.GetComponent<Animator>().SetTrigger("Shoot");
                            Instantiate(bulletR, LeftF.transform.position, Quaternion.Euler(0, 0, 90));
                        }
                        if (dir == "Right")
                        {
                            RightF.SetActive(true);
                            rightA.GetComponent<Animator>().SetTrigger("Shoot");
                            Instantiate(bulletR, RightF.transform.position, Quaternion.Euler(0, 0, 270));
                        }
                        atk = 1;
                        time = 0f;
                        Gm.RedBullet -= 1;
                    }
                }
            }
            if (atk == 1)
            {
                if (time < 0.15)
                {
                    time += Time.deltaTime;
                }
                else
                {
                    FrontF.SetActive(false);
                    BackF.SetActive(false);
                    LeftF.SetActive(false);
                    RightF.SetActive(false);
                    atk = 0;
                }
            }
        }
        
    }

    void SlowSys()
    {
        if (slow >= 0)
        {
            slow -= Time.deltaTime;
            slowimg.SetActive(true);
        }
        else
        {
            if (slowspeed != 0)
            {
                speed += slowspeed;
                slowspeed = 0;
            }
            slowimg.SetActive(false);
        }
    }

    void Ani()
    {
        if (vector.y != 0 && vector.x > 0)
        {
            right.SetActive(true);
            left.SetActive(false);
            front.SetActive(false);
            back.SetActive(false);
            dir = "Right";
        }
        else if (vector.y != 0 && vector.x < 0)
        {
            left.SetActive(true);
            right.SetActive(false);
            front.SetActive(false);
            back.SetActive(false);
            dir = "Left";
        }
        else if (vector.x < 0)
        {
            left.SetActive(true);
            right.SetActive(false);
            front.SetActive(false);
            back.SetActive(false);
            dir = "Left";
        }
        else if (vector.x > 0)
        {
            right.SetActive(true);
            left.SetActive(false);
            front.SetActive(false);
            back.SetActive(false);
            dir = "Right";
        }
        else if (vector.y < 0)
        {
            front.SetActive(true);
            back.SetActive(false);
            right.SetActive(false);
            left.SetActive(false);
            dir = "Front";
        }
        else if(vector.y > 0)
        {
            back.SetActive(true);
            front.SetActive(false);
            right.SetActive(false);
            left.SetActive(false);
            dir = "Back";
        }
        
        if (vector.y != 0 || vector.x != 0)
        {
            leftA.SetActive(false);
            rightA.SetActive(false);
            frontA.SetActive(false);
            backA.SetActive(false);
        }
        if (vector.x == 0 && vector.y == 0)
        {
            atkAni();
        }
    }

    void atkAni()
    {
        left.SetActive(false);
        right.SetActive(false);
        front.SetActive(false);
        back.SetActive(false);
        if (dir == "Right")
        {
            rightA.SetActive(true);
        }
        else if (dir == "Left")
        {
            leftA.SetActive(true);
        }
        else if (dir == "Front")
        {
            frontA.SetActive(true);
        }
        else if (dir == "Back")
        {
            backA.SetActive(true);
        }
    }

    public void GetSlow()
    {
        if(slow <= 0)
        {
            slow = 3;
            slowspeed = speed * 0.2f;
            speed -= slowspeed;
            
        }
        else
        {
            slow += 1;
        }
    }

    void Reload()
    {
        int A = 30;
        audiosource.PlayOneShot(re);
        A -= Gm.Bullet;
        if(Gm.MaxBullet >= A)
        {
            Gm.Bullet = 30;
            Gm.MaxBullet -= A;
        }
        else
        {
            Gm.Bullet += Gm.MaxBullet;
            Gm.MaxBullet = 0;
        }
        rerall.SetActive(false);
        reload = 0;
    }

}
