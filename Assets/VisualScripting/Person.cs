using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    private Vector2 direction;
    public float speed;
    private Rigidbody2D rb;
    private bool onfire;
    public ParticleSystem fire;
    private SpriteRenderer sr1, sr2;
    private float walkTime;
    // Start is called before the first frame update
    void Start()
    {
        walkTime = Random.Range(1, 3);
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Wander());
        sr1 = gameObject.GetComponent<SpriteRenderer>();
        sr2 = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private IEnumerator Wander()
    {
        while (true)
        {
            direction = new Vector2((Random.value - 0.5f) * 2, (Random.value - 0.5f) * 2);
            Debug.Log(direction);
            rb.velocity = direction * speed;
            yield return new WaitForSeconds(walkTime);
            rb.velocity = Vector2.zero;
            if (!onfire)
            {
                yield return new WaitForSeconds(2);
            }
        }
    }

    private IEnumerator Burn()
    {
        Color lastColor1 = sr1.color;
        Color lastColor2 = sr2.color;
        float timer = 0;
        while (sr1.color != Color.black && sr2.color != Color.black)
        {
            timer += Time.deltaTime;
            sr1.color = new Color(Mathf.Lerp(lastColor1.r, 0, timer / 10), Mathf.Lerp(lastColor1.g, 0, timer / 10), Mathf.Lerp(lastColor1.b, 0, timer / 10));
            sr2.color = new Color(Mathf.Lerp(lastColor2.r, 0, timer / 10), Mathf.Lerp(lastColor2.g, 0, timer / 10), Mathf.Lerp(lastColor2.b, 0, timer / 10));
            yield return new WaitForEndOfFrame();
        }
    }

    public void OnFire()
    {
        speed = 5;
        fire.Play();
        Destroy(gameObject, 10);
        StartCoroutine(Burn());
        if (!onfire)
        {
            GetComponent<AudioSource>().Play();
        }
        onfire = true;
    }
}
