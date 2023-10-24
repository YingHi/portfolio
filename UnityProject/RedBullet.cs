using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : MonoBehaviour
{
    public float bulletSpeed;
    int fire = 1;
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = gameObject.GetComponent<AudioSource>();
        Invoke("DestroyBullet", 4);
    }

    // Update is called once per frame
    void Update()
    {
        if(fire == 1)
        {
            transform.Translate(0, bulletSpeed * Time.deltaTime, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            audiosource.Play();
            fire = 0;
            GetComponent<Animator>().SetTrigger("Boom");
        }
        if (collision.gameObject.CompareTag("Ob"))
        {
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    void BulletBoom()
    {
        Collider2D[] collider2d = Physics2D.OverlapBoxAll(transform.position, new Vector2(5, 5), 0);
        foreach(Collider2D c2d in collider2d)
        {
            if(c2d.tag == "Enemy")
            {
                c2d.gameObject.GetComponent<EnemyManager>().HP -= 70;
                c2d.gameObject.GetComponent<EnemyManager>().Stun(2.5f); 
                DestroyBullet();
            }
        }
    }
}
