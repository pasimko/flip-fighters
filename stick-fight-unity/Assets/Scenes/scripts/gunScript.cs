using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public GameObject gunPrefab;
    public GameObject projectilePrefab;
    public int rateOfFire, ammoCapacity;
    public Vector3 direction;

    public void fire()
    {
        Instantiate(projectilePrefab);
    }
}
