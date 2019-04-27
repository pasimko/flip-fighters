using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public GameObject gunPrefab;
    public GameObject projectilePrefab;
    public int rateOfFire, ammoCapacity;
    public Vector3 direction;

    // Which player is wielding it: 0 = nobody, 1 = player1, 2 = player2
    public int equippedBy = 0;
    
    bool equipped = false;

    GameObject tempBullet;

    public void fire()
    {
        tempBullet = Instantiate(projectilePrefab, transform.position, transform.rotation);
        tempBullet.GetComponent<Projectile>().owner = equippedBy;
    }
}
