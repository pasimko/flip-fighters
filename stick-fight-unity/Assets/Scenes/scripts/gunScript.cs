using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public GameObject gunPrefab;
    public GameObject projectilePrefab;
    public int rateOfFire, damage, velocity, lifetime, size;
    public bool canHurtSelf, useGravity;

    public void fire()
    {
        Instantiate(projectilePrefab);
    }
}
