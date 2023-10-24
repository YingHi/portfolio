using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadeIn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().SetTrigger("SceneIn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
