using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    Slider slider; // 슬라이더
    public GameObject Ride;
    public float time; // 시간 변수
    public int Money, Bill; // 클릭 시 벌 돈
    public bool execute_gauge, ready; // 고장 여부, 대기 여부
    private static float trouble, trouble_num; // 고장 쿨타임, 고장난수
    public GameManager Gm;
    AudioSource audioSource;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 0;
        time = 0.0f;
        execute_gauge = true;
        trouble = 3.0f;
        trouble = 0f;
        trouble_num = 3f;
        ready = false;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (ready == false && execute_gauge) // 정상 작동 상태라면
        {
            if (Gm.needfix)
            {
                if (trouble < 0) trouble_num = Random.Range(1, 5000); // 고장 쿨이 돌았으면 고장 난수를 받음
                else trouble -= Time.deltaTime; // 고장 쿨이 안 돌았으면 고장 쿨을 돌림
                if (trouble_num < 2) Trouble(); // 고장 난수가 2 이하라면 고장함수 작동
            }
            if (execute_gauge) MoveGauge(); // 고장나지않았다면 게이지함수 작동
        }
    }

    void Trouble() // 놀이기구를 고장내는 고장함수
    {
        audioSource.Play();
        execute_gauge = false; // 고장내버림
        Ride.GetComponent<Animator>().SetBool("is_trouble", true); // 놀이기구를 흑백으로 전환
        slider.fillRect.GetComponent<Image>().color = Color.red; // 슬라이더를 붉게 만듬
    }

    public void Repair() // 고장난 놀이기구를 수리하는 함수
    {
        execute_gauge = true; // 수리해버림
        Ride.GetComponent<Animator>().SetBool("is_trouble", false); // 놀이기구를 다시 작동
        slider.fillRect.GetComponent<Image>().color = Color.green; // 슬라이더를 녹색으로 만듬
    }

    private void MoveGauge() // 게이지를 작동시키는 게이지함수
    {
        if (slider.value < slider.maxValue) // 슬라이더 게이지가 최대치보다 낮다면
        {
            time += Time.deltaTime; // 게이지 시간이 흐름
            slider.value = time; // 시간에 맞춰 게이지 조작
        }
        else // 슬라이더 게이지가 최대치 이상이라면
        {
            ready = true; // 작동 끝이므로 대기 상태로 바꿈
            slider.fillRect.GetComponent<Image>().color = Color.yellow; // 슬라이더를 노랗게 만듬
        }
    }

    public void ResetTimer() // 작동 끝 놀이기구를 다시 작동시키고 타이머를 리셋시키며 돈을 벌음
    {
        Gm.addMoney(Money);
        ready = false; // 대기상태를 해제함
        time = 0.0f; // 시간 초기화
        slider.value = time; // 슬라이더 초기화
        slider.fillRect.GetComponent<Image>().color = Color.green; // 슬라이더를 녹색으로 만듬
    }
}

    
