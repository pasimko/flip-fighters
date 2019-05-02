using System.Collections;
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
        tempBullet.gameObject.GetComponent<Projectile>().owner = equippedBy;
        ignorePlayer(tempBullet);
        Physics2D.IgnoreCollision(tempBullet.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
    }

    void OnCollisionEnter2D(Collision2D collision) {
        //player1
        if (!equipped) {
            if (collision.collider.gameObject.layer == 10 && !player1.GetComponent<PlayerController>().hasGun) {
                equippedBy = player1;
                Transform playerHand = GameObject.Find("player1/rightArm/gunHolder").transform;
                equipGun(ref playerHand, ref player1);
                gameObject.transform.localScale = new Vector3(-1f, -1f, 1f);
                ignorePlayer(gameObject);
            }
            else if (collision.collider.gameObject.layer == 11 && !player2.GetComponent<PlayerController>().hasGun) {
                equippedBy = player2;
                Transform playerHand = GameObject.Find("player2/leftArm/gunHolder").transform;
                equipGun(ref playerHand, ref player2);
                gameObject.transform.localScale = new Vector3(-1f, -1f, 1f);
                ignorePlayer(gameObject);
            }
        }
    }
    
    void equipGun(ref Transform playerHand, ref GameObject player) {
        gameObject.layer = player.layer;
        equipped = true;

        player.GetComponent<PlayerController>().hasGun = true;
        player.GetComponent<PlayerController>().currentGun = gameObject.GetComponent<gunScript>();
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        gameObject.transform.SetParent(playerHand, true);
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localRotation = Quaternion.identity;
        gameObject.transform.localRotation = Quaternion.AngleAxis(90, Vector3.forward);
        //gameObject.transform.localEulerAngles.y=0;
        //gameObject.transform.localEulerAngles.z=0;
    }

    void ignorePlayer(GameObject ignored) {
        Physics2D.IgnoreCollision(ignored.GetComponent<Collider2D>(), equippedBy.GetComponent<PlayerController>().head.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(ignored.GetComponent<Collider2D>(), equippedBy.GetComponent<PlayerController>().body.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(ignored.GetComponent<Collider2D>(), equippedBy.GetComponent<PlayerController>().leftLeg.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(ignored.GetComponent<Collider2D>(), equippedBy.GetComponent<PlayerController>().rightLeg.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(ignored.GetComponent<Collider2D>(), equippedBy.GetComponent<PlayerController>().leftArm.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(ignored.GetComponent<Collider2D>(), equippedBy.GetComponent<PlayerController>().rightArm.GetComponent<Collider2D>());
    }

}
