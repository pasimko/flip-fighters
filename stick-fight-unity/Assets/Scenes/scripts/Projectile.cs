using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D projectile;
    //Create a projectile with these initial properties
    public void Initialize(Vector3 position, Vector3 velocity, Vector3 size, float lifetime, float damage, List<PlayerController> targets, Rigidbody2D prefab, bool physicsControlled)
    {
        projectile = Instantiate(prefab, position, Quaternion.identity);
        projectile.velocity = velocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];

        // Rotate the object so that the y-axis faces along the normal of the surface
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        Destroy(gameObject);
    }
}
