using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage, velocity, lifetime, size;
    public bool canHurtSelf, useGravity;

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("bullet collision");
        Destroy(gameObject);
    }
}
