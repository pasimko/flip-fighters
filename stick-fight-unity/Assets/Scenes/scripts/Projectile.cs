using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Transform projectile;
    //Create a projectile with these initial properties
    public void Initialize(Vector3 position, Vector3 velocity, Vector3 size, float lifetime, float damage, List<PlayerController> targets, Transform prefab)
    {
        projectile = Instantiate(prefab, position, Quaternion.identity);
    }
}
