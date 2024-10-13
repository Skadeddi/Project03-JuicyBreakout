using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeball : MonoBehaviour
{
    private GameObject ball;
    void Start()
    {
        ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = (ball.transform.position - transform.position);
    }
}
