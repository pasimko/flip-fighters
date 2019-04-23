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
        //projectile.position.z = 10;
        //projectile.velocity = velocity;
    }
}
