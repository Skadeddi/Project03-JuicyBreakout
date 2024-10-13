using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawner : MonoBehaviour
{
    public GameObject person;
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            Instantiate(person, new Vector3(Random.Range(-5, 5), Random.Range(-5, 5)), Quaternion.Euler(0, 0, 0));
        }
    }
}
