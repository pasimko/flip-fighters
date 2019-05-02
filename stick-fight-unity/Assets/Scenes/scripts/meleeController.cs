using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeController : MonoBehaviour
{
    float timer = 0.2f;
    public GameObject owner;

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
        if (collision.gameObject.tag != owner.tag)
        {
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(10f, 10f));
        }
        Destroy(gameObject);
        Debug.Log("melee");
    }
}
