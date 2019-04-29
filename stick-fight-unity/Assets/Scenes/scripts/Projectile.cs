using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage, velocity, lifetime, size;
    public bool useGravity;

    public int owner;

    void Awake() {
        //velocity = new Vector2(transform.right * velocity * 100f, 0f);
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * velocity * 100);
    }

    void Update() {
        if (gameObject.transform.position.y < -50) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("bullet collision");
        Destroy(gameObject);
    }
}
