using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour
{
    private Camera cam;
    public float magnitude, damping;
    private float duration;
    private Vector3 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        initialPos = cam.transform.position;
    }

    public void TriggerShake(float t)
    {
        duration = t;
    }
    
    void Update()
    {
        if(duration > 0)
        {
            cam.transform.position = initialPos + Random.insideUnitSphere * magnitude;
            duration -= Time.deltaTime * damping;
        }
        else
        {
            duration = 0;
            cam.transform.position = initialPos;
        }
    }
}
