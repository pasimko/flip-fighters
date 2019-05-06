using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeController : MonoBehaviour
{
    float timer = 0.2f;
    public GameObject owner;
    public float damageMult = 1;
    public float knockbackMult = 1;
    bool hasCollided = false;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != owner.tag && !hasCollided)
        {
            Debug.Log(knockbackMult);
            collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 40f * knockbackMult * knockbackMult);
            collision.GetComponent<Rigidbody2D>().AddExplosionForce(500*knockbackMult, owner.GetComponent<PlayerController>().body.position, 5f, 5f*knockbackMult);
            Destroy(gameObject);
            collision.transform.parent.gameObject.GetComponent<PlayerController>().health -= damageMult*2;
            hasCollided = true;
        }
    }
}
