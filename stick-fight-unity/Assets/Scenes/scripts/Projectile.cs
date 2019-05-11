using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage, velocity, lifetime, size;
    public bool useGravity;

    public GameObject owner;

    void Start() {
        gameObject.layer = owner.layer + 2;
        gameObject.transform.parent.gameObject.layer = owner.layer + 2;
        gameObject.transform.parent.parent.Find("body").gameObject.layer = owner.layer + 2;
        gameObject.transform.parent.parent.Find("rightArm").gameObject.layer = owner.layer + 2;
        gameObject.transform.parent.parent.Find("leftArm").gameObject.layer = owner.layer + 2;
        gameObject.transform.parent.parent.Find("leftLeg").gameObject.layer = owner.layer + 2;
        gameObject.transform.parent.parent.Find("rightLeg").gameObject.layer = owner.layer + 2;
        //Set the velocity based on the rotation of the bullet. 
        //Bullet is rotated based on the gun's rotation upon instantiation
        Debug.Log(transform.gameObject.name);
        transform.parent.GetComponent<Rigidbody2D>().AddForce(transform.right * velocity * 100);

    }

    void Update() {
        //Destroy if it's off the map
        if (gameObject.transform.position.y < -20) {
            Destroy(transform.parent.parent.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == owner.GetComponent<PlayerController>().otherPlayer.gameObject.layer) 
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right*150);
        }
        Destroy(transform.parent.parent.gameObject);
    }
}
