using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public GameObject Water;

    private void Start()
    {
        Respawn();
    }
    void MakeWater()
    {
        float pointA = Random.Range(-3, 3);
        float pointB = Random.Range(-3, 3);
        Water.transform.position = new Vector3(transform.position.x + pointA, transform.position.y + pointB, 0);
        Water.SetActive(true);
    }

    public void Respawn()
    {
        Invoke("MakeWater", 10);
    }
}
