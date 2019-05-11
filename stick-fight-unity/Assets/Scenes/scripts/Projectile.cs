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
        gameObject.transform.parent.GetComponent<Rigidbody2D>().mass = 5;
        gameObject.transform.parent.parent.Find("body").GetComponent<Rigidbody2D>().mass = 5;
        gameObject.transform.parent.parent.Find("rightArm").GetComponent<Rigidbody2D>().mass = 5;
        gameObject.transform.parent.parent.Find("leftArm").GetComponent<Rigidbody2D>().mass = 5;
        gameObject.transform.parent.parent.Find("leftLeg").GetComponent<Rigidbody2D>().mass = 5;
        gameObject.transform.parent.parent.Find("rightLeg").GetComponent<Rigidbody2D>().mass = 5;
        //Destroy if it's off the map
        if (gameObject.transform.position.y < -20) {
            Destroy(transform.parent.parent.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(transform.parent.parent.gameObject);
    }
}
