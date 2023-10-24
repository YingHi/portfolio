using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;

    void Start()
    {
        Invoke("DestroyBullet", 2);
    }

    void Update()
    {
        transform.Translate(0, bulletSpeed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyManager>().HP -= 50;
            collision.gameObject.GetComponent<EnemyManager>().Stun(0.3f);
            DestroyBullet();
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
}
