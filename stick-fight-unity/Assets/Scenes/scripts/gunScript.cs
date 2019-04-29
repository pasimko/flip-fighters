﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{

    public GameObject projectilePrefab;
    public int rateOfFire, ammoCapacity;
    public Vector3 direction;

    public Transform barrel;

    GameObject player1, player2;

    public GameObject equippedBy;
    bool equipped = false;

    GameObject tempBullet;

    void Start() {
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");
    }

    public void fire()
    {
        tempBullet = Instantiate(projectilePrefab, barrel.position, transform.rotation);
        Debug.Log("a");
        tempBullet.gameObject.GetComponent<Projectile>().owner = equippedBy;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        //player1
        if (!equipped) {
            if (collision.collider.gameObject.layer == 10 && !player1.GetComponent<PlayerController>().hasGun) {
                Transform playerHand = GameObject.Find("player1/rightArm/gunHolder").transform;
                equipGun(playerHand, player1);
                gameObject.transform.localScale = new Vector3(-0.3f/0.1592316f, 0.3f, 0.3f);
                equippedBy = player1;
            }
            else if (collision.collider.gameObject.layer == 11 && !player2.GetComponent<PlayerController>().hasGun) {
                Transform playerHand = GameObject.Find("player2/leftArm/gunHolder").transform;
                equipGun(playerHand, player2);
                gameObject.transform.localScale = new Vector3(-0.3f/0.1592316f, -0.3f, 0.3f);
                equippedBy = player2;
            }
        }
    }
    
    void equipGun(Transform playerHand, GameObject player) {
        gameObject.layer = player.layer;
        equipped = true;

        player.GetComponent<PlayerController>().hasGun = true;
        player.GetComponent<PlayerController>().currentGun = gameObject.GetComponent<gunScript>();
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        //Destroy(gameObject.GetComponent<BoxCollider2D>());
        gameObject.transform.SetParent(playerHand, false);
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localRotation = Quaternion.identity;
    }
}
