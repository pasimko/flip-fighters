using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeController : MonoBehaviour
{

    //Attached to invisible rectangular hitbox
    //Hitbox despawns after 0.2s with no collisions
    float timer = 0.2f;
    //We will ignore this gameObject's collisions
    public GameObject owner;

    //Multipliers for damage and knockback from flips
    public float damageMult = 1;
    public float knockbackMult = 1;
    bool hasCollided = false;

    // Update is called once per frame
    void Update()
    {
        //Countdown after instantiation to destroy gameobject
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
            //Knock target into the air
            collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 40f * knockbackMult * knockbackMult);
            //Explosion force to make knockback relative to the position of the player
            collision.GetComponent<Rigidbody2D>().AddExplosionForce(500*knockbackMult, owner.GetComponent<PlayerController>().body.position, 5f, 5f*knockbackMult);
            Destroy(gameObject);
            //Do damage
            collision.transform.parent.gameObject.GetComponent<PlayerController>().health -= damageMult*3;
            hasCollided = true;
        }
    }
}
