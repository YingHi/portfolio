using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    Slider slider; // �����̴�
    public GameObject Ride;
    public float time; // �ð� ����
    public int Money, Bill; // Ŭ�� �� �� ��
    public bool execute_gauge, ready; // ���� ����, ��� ����
    private static float trouble, trouble_num; // ���� ��Ÿ��, ���峭��
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
        if (ready == false && execute_gauge) // ���� �۵� ���¶��
        {
            if (Gm.needfix)
            {
                if (trouble < 0) trouble_num = Random.Range(1, 5000); // ���� ���� �������� ���� ������ ����
                else trouble -= Time.deltaTime; // ���� ���� �� �������� ���� ���� ����
                if (trouble_num < 2) Trouble(); // ���� ������ 2 ���϶�� �����Լ� �۵�
            }
            if (execute_gauge) MoveGauge(); // ���峪���ʾҴٸ� �������Լ� �۵�
        }
    }

    void Trouble() // ���̱ⱸ�� ���峻�� �����Լ�
    {
        audioSource.Play();
        execute_gauge = false; // ���峻����
        Ride.GetComponent<Animator>().SetBool("is_trouble", true); // ���̱ⱸ�� ������� ��ȯ
        slider.fillRect.GetComponent<Image>().color = Color.red; // �����̴��� �Ӱ� ����
    }

    public void Repair() // ���峭 ���̱ⱸ�� �����ϴ� �Լ�
    {
        execute_gauge = true; // �����ع���
        Ride.GetComponent<Animator>().SetBool("is_trouble", false); // ���̱ⱸ�� �ٽ� �۵�
        slider.fillRect.GetComponent<Image>().color = Color.green; // �����̴��� ������� ����
    }

    private void MoveGauge() // �������� �۵���Ű�� �������Լ�
    {
        if (slider.value < slider.maxValue) // �����̴� �������� �ִ�ġ���� ���ٸ�
        {
            time += Time.deltaTime; // ������ �ð��� �帧
            slider.value = time; // �ð��� ���� ������ ����
        }
        else // �����̴� �������� �ִ�ġ �̻��̶��
        {
            ready = true; // �۵� ���̹Ƿ� ��� ���·� �ٲ�
            slider.fillRect.GetComponent<Image>().color = Color.yellow; // �����̴��� ����� ����
        }
    }

    public void ResetTimer() // �۵� �� ���̱ⱸ�� �ٽ� �۵���Ű�� Ÿ�̸Ӹ� ���½�Ű�� ���� ����
    {
        Gm.addMoney(Money);
        ready = false; // �����¸� ������
        time = 0.0f; // �ð� �ʱ�ȭ
        slider.value = time; // �����̴� �ʱ�ȭ
        slider.fillRect.GetComponent<Image>().color = Color.green; // �����̴��� ������� ����
    }
}

    
