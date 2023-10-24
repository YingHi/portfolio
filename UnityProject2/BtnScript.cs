using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnScript : MonoBehaviour
{
    public GameObject Ride;
    public Sprite sprite, sprite2;

    private void OnMouseDown()
    {
        Ride.SetActive(true);
    }

    public void Push()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        Invoke("Pull",0.1f);
    }

    void Pull()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
    }

}
