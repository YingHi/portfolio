using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioClip dead1, dead2, dead3;
    AudioSource audiosource;
    public Dictionary<int, GameObject> Normal;
    public Dictionary<int, GameObject> Elite;
    public Dictionary<int, Transform> Point;
    public PlayerManager Player;
    public TalkManager talkManager;
    public Transform point1, point2, point3, point4;
    public GameObject textUI, invin, normal1, normal2, normal3, elite1, elite2, elite3, Boss, ReBtn, QuitBtn, Clear, Over;
    public Text text, setText;
    public Slider HPbar;
    public bool isTalk;
    public int min, max, Bullet, MaxBullet, RedBullet, Kills, Round, Ecount, elitec, MaxEnemy, Phase;
    float invincible;
    public float HP;
    public GameObject Panel;
    string rank;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = gameObject.GetComponent<AudioSource>();
        Normal = new Dictionary<int, GameObject>();
        Elite = new Dictionary<int, GameObject>();
        Point = new Dictionary<int, Transform>();
        HP = 100;
        isTalk = false;
        min = 1;
        max = 0;
        Bullet = 30;
        MaxBullet = 0;
        RedBullet = 0;
        invincible = 0;
        Kills = 0;
        Ecount = 0;
        setRound(1);
        AddEnemy();
        elitec = 0;
        Phase = 2;
        InvokeRepeating("genEnemy", 0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        GameClose();
        Reload();
        HPSys();
        TalkSys();
        genEnemy();
    }

    public void deadEnemy()
    {
        int a = Random.Range(1, 4);
        if (a == 1) audiosource.PlayOneShot(dead1);
        if (a == 2) audiosource.PlayOneShot(dead2);
        if (a == 3) audiosource.PlayOneShot(dead3);
        Kills += 1;
        Ecount -= 1;
    }

    void AddEnemy()
    {
        Normal.Add(1, normal1);
        Normal.Add(2, normal2);
        Normal.Add(3, normal3);
        Elite.Add(1, elite1);
        Elite.Add(2, elite2);
        Elite.Add(3, elite3);
        Point.Add(1, point1);
        Point.Add(2, point2);
        Point.Add(3, point3);
        Point.Add(4, point4);
    }

    public void setRound(int A)
    {
        Round = A;
        MaxEnemy = 10 + A * 4;
        if (Round == 2) Phase = 3;
        if (Round == 3){
            Instantiate(Boss, Point[1]);
            inpTalk(141, 142);
        } 
        if (Round == 4) Phase = 4;
        if (Round == 5) Instantiate(Boss, Point[2]);
        if (Round == 6) {
            Instantiate(Boss, Point[3]);
            Instantiate(Boss, Point[4]);
        }
        if (Round == 7) inpTalk(161, 161);
        
    }

    public void GameClose()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }

    public void GameOver()
    {
        Over.SetActive(true);
        GameSet();
    }

    public void GameClear()
    {
        Clear.SetActive(true);
        GameSet();
    }

    void GameSet()
    {
        if (Kills > 650) rank = "SSS";
        else if (Kills > 550) rank = "SS";
        else if (Kills > 450) rank = "S";
        else if (Kills > 300) rank = "A";
        else if (Kills > 200) rank = "B";
        else if (Kills > 100) rank = "C";
        else if (Kills > 50) rank = "D";
        else rank = "F";
        Time.timeScale = 0;
        Panel.GetComponent<Animator>().SetTrigger("Scene");
        ReBtn.SetActive(true);
        QuitBtn.SetActive(true);
        setText.text = "Kills : " + Kills + "\nRank : " + rank;
    }
    
    void genEnemy()
    {
        if(Ecount < MaxEnemy)
        {
            int elite = Random.Range(1, 5); 
            int rd = Random.Range(1, Phase);
            int genp = Random.Range(1, 5);
            elitec += 1;
            if (elite == 1 || elitec == 4)
            {
                Instantiate(Elite[rd], Point[genp]);
                elitec = 0;
            }
            else
            {
                Instantiate(Normal[rd], Point[genp]);
            }
            Ecount += 1;
        }
    }

    public void inpTalk(int minn, int maxx)
    {
        max = maxx;
        min = minn;
    }

    void TalkSys()
    {
        if (min <= max)
        {
            isTalk = true;
            Talk(min, max);
        }
        else if (min > max)
        {
            isTalk = false;
        }
        if (isTalk)
        {
            Time.timeScale = 0;
            textUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            textUI.SetActive(false);
        }
    }

    void Talk(int minn, int maxn)
    {
        isTalk = true;
        text.text = talkManager.GetComponent<TalkManager>().Data[minn];
        if(Input.GetKeyDown(KeyCode.Space)) min += 1;
    }

    void HPSys()
    {
        HP -= 0.5f * Time.deltaTime;
        HPbar.value = HP;
        if (invincible > 0)
        {
            invincible -= Time.deltaTime;
            invin.SetActive(true);
        }
        else
        {
            invin.SetActive(false);
        }
    }

    public void GetDmg(int Atk)
    {
        if(invincible <= 0 )
        {
            HP -= Atk;
            if(Atk != 2)
            {
                invincible = 2;
            }
            
        }
    }

    void Reload()
    {
        if(Player.reload == 0)
        {
            if (MaxBullet != 0)
            {
                if (Bullet == 0)
                {
                    Player.reload = 1;
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    if(Bullet < 30)
                    {
                        Player.reload = 1;
                    }
                }
            }
            
        }
        
    }
}
