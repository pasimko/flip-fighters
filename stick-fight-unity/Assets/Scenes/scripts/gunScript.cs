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

    float timer = 10.0f;

    GameObject tempBullet;

    void Start() 
    {
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");
    }
    void Update() 
    {
        if (equipped) {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                
                equippedBy.GetComponent<PlayerController>().hasGun = false;
                equippedBy.GetComponent<PlayerController>().currentGun = null;
                gameObject.transform.parent = null;
                Destroy(gameObject.GetComponent<CircleCollider2D>());
                gameObject.AddComponent<Rigidbody2D>();
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), 0));
                gameObject.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-20, 20));
                Destroy(this);
            }
        }
    }

    public void fire()
    {
        //Recoil forces
        equippedBy.GetComponent<PlayerController>().body.AddForce(transform.right*-100);
        equippedBy.GetComponent<PlayerController>().head.AddForce(new Vector3(0, 50, 0));

        //Projectile is instantiated and rotated at the correct position and oriented based on the player
        tempBullet = Instantiate(projectilePrefab, transform.position, transform.rotation);
        
        tempBullet.transform.Find("head/collider").GetComponent<Projectile>().owner = equippedBy;
        //Ignore the owner
        ignorePlayer(tempBullet);
        Physics2D.IgnoreCollision(tempBullet.transform.parent.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
    }

    void OnCollisionEnter2D(Collision2D collision) {
        //player1
        if (!equipped) {
            if (collision.collider.gameObject.layer == 10 && !player1.GetComponent<PlayerController>().hasGun) {
                equippedBy = player1;
                Transform playerHand = GameObject.Find("player1/rightArm/gunHolder").transform;
                equipGun(ref playerHand, ref player1);

                //Change scale in order to maintain scaling before it was childed
                gameObject.transform.localScale = new Vector3(-3f, 3f, 1f);
                ignorePlayer(transform.parent.gameObject);
            }
            else if (collision.collider.gameObject.layer == 11 && !player2.GetComponent<PlayerController>().hasGun) {
                equippedBy = player2;
                Transform playerHand = GameObject.Find("player2/leftArm/gunHolder").transform;
                equipGun(ref playerHand, ref player2);

                //Change scale in order to maintain scaling before it was childed
                gameObject.transform.localScale = new Vector3(-3f, -3f, 1f);
                ignorePlayer(transform.parent.gameObject);
            }
        }
    }
    
    void equipGun(ref Transform playerHand, ref GameObject player) {
        gameObject.layer = player.layer;
        equipped = true;

        player.GetComponent<PlayerController>().hasGun = true;
        player.GetComponent<PlayerController>().currentGun = gameObject.GetComponent<gunScript>();

        //We don't want the orb physically interacting with the map anymore
        Destroy(gameObject.GetComponent<Rigidbody2D>());

        Destroy(gameObject.GetComponent<BoxCollider2D>());

        //Setting parent can mess up position and rotation, so we reset
        gameObject.transform.SetParent(playerHand, true);
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localRotation = Quaternion.identity;
        //gameObject.transform.localRotation = Quaternion.AngleAxis(90, Vector3.forward);
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
