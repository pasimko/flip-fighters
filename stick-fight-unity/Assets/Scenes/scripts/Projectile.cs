using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage, velocity, lifetime, size;
    public bool useGravity;

    public GameObject owner;

    public 

    void Start() {
        //Set the velocity based on the rotation of the bullet. 
        //Bullet is rotated based on the gun's rotation upon instantiation
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * velocity * 100);
        Physics2D.IgnoreLayerCollision(0, owner.layer);
    }

    void Update() {
        //Destroy if it's off the map
        if (gameObject.transform.position.y < -20) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
