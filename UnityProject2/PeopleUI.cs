using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleUI : MonoBehaviour
{   
    enum PeopleState
    {
        Idle,
        Walk
    }

    SpriteRenderer flipSprite;
    public float positionX, positionY, speed, MadCount;
    int StateMad, MadClickCount;
    public GameManager gm;
    AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        flipSprite = GetComponent<SpriteRenderer>();
        Walk();
    }

    void Update()
    {
        if (positionX > 0) flipSprite.flipX = false;
        else flipSprite.flipX = true; // 바라보는 방향 결정

        if (transform.position.x < -9.0) positionX = Random.Range(0f, 2.0f);
        if (transform.position.x > 9.0) positionX = Random.Range(-2.0f, 0f);
        if (transform.position.y < -9.0) positionY = Random.Range(0.0f, 2.0f);
        if (transform.position.y > 4.5) positionY = Random.Range(-2.0f, 0f);

        if (gameObject.tag == "MadPeople")
        {
            MadCount -= Time.deltaTime;
            if (MadCount <= 0) MadMan();
        }

        transform.Translate(new Vector2(positionX, positionY) * speed * Time.deltaTime); // 이동
    }

    private void Walk()
    {
        speed = Random.Range(0.3f, 0.5f);
        positionX = Random.Range(-2.0f, 2.0f);
        positionY = Random.Range(-2.0f, 2.0f);

        if (gm.mad)
        {
            StateMad = Random.Range(0, 15);
            if (StateMad == 1)
            {
                audioSource.Play();
                gameObject.tag = "MadPeople"; // 랜덤하게 화내기
                GetComponent<Animator>().SetBool("is_Mad", true);
                MadClickCount = Random.Range(3, 9);
                MadCount = Random.Range(5, 9);
            }
            else
            {
                gameObject.tag = "People";
                Invoke("Walk", Random.Range(4.0f, 7.0f)); // 랜덤한 시간마다 걷기
            }
        }
        else
        {
            gameObject.tag = "People";
            Invoke("Walk", Random.Range(4.0f, 7.0f)); // 랜덤한 시간마다 걷기
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            if(transform.position.x > collision.gameObject.transform.position.x) positionX = Random.Range(1, 9.0f);
            if (transform.position.x < collision.gameObject.transform.position.x) positionX = Random.Range(-9.0f, -1.0f);
            if (transform.position.y > collision.gameObject.transform.position.y) positionY = Random.Range(1f, 5.0f);
            if (transform.position.y < collision.gameObject.transform.position.y) positionY = Random.Range(-9.0f, -1.0f);
        }
    }

    private void OnMouseDown()
    {
        if (gameObject.tag == "MadPeople")
        {
            MadClickCount -= 1;
            if(MadClickCount < 0)
            {
                GetComponent<Animator>().SetBool("is_Mad", false);
                gameObject.tag = "People";
                Walk();
            }
        }
    }

    void MadMan()
    {
        gm.ToMoney += 10000000;
        gameObject.tag = "People";
        GetComponent<Animator>().SetBool("is_Mad", false);
        Walk();
    }
}
