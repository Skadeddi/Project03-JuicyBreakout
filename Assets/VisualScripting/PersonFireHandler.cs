using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonFireHandler : MonoBehaviour
{
    private Person pp;
    private void Start()
    {
        pp = transform.GetComponentInParent<Person>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            pp.OnFire();
        }
    }
}
