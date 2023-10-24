using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject tree;
    public void Respawn()
    {
        gameObject.SetActive(false);
        tree.GetComponent<Tree>().Respawn();
    }
}
