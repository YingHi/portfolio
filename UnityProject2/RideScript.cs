using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideScript : MonoBehaviour
{
    public SliderScript Slide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() // 이 오브젝트를 클릭했을 때
    {
        if (Slide.execute_gauge == false) Slide.Repair();
        else if (Slide.ready == true) Slide.ResetTimer();
        else Slide.time += 1.25f;
    }

}
