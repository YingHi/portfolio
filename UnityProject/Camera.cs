using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Player;
    Vector3 move;

    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y,-10);
        if (transform.position.x < -54) transform.position = new Vector3(-54, transform.position.y, -10);
        if (transform.position.x > 50) transform.position = new Vector3(50, transform.position.y, -10);
        if (transform.position.y < -60) transform.position = new Vector3(transform.position.x, -60, -10);
        if (transform.position.y > 60) transform.position = new Vector3(transform.position.x, 60,-10);
    }
}
