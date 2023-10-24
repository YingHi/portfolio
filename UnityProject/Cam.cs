using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject Player;
    Vector3 move;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 3, -10);
        if (transform.position.x != 0) transform.position = new Vector3(0, transform.position.y, -10);
        if (transform.position.y < 0) transform.position = new Vector3(transform.position.x, 0, -10);
        if (transform.position.y > 41) transform.position = new Vector3(transform.position.x, 41, -10);
    }
}
