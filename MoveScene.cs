using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScene : MonoBehaviour
{
    public GameObject title, plane, cameraMove;
    public GameObject[] button;

    void Start()
    {
        for (int i = 0; i < 3; i++) button[i].SetActive(false);
        
    }
    void Update()
    {
        // 카메라 이동
        if (cameraMove.transform.position.y >= -2.0f) cameraMove.transform.Translate(Vector2.down * 0.8f * Time.deltaTime);
        
        // 타이틀 이동
        iTween.MoveTo(title, iTween.Hash("y", 0.1f, "delay", 3.5f, "time", 1.5f));

        // 버튼 생성
        if (title.transform.position.y <= 0.5f) for (int i = 0; i < 3; i++) button[i].SetActive(true);

        // 비행기 이동
        if (plane.transform.position.x <= 0f) plane.transform.Translate(new Vector2(1, 0.5f) * Time.deltaTime);
    }
}
