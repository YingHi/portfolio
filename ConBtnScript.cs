using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConBtnScript : MonoBehaviour
{
    public GameObject Circle, Ride, Slide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    private void OnMouseDown()
    {
        Ride.SetActive(true);
        Slide.SetActive(true);
        Circle.SetActive(false);
    }
}
