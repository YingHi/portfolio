using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RedBulletText : MonoBehaviour
{
    TextMeshProUGUI Text;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = gm.RedBullet + "";
    }
}
