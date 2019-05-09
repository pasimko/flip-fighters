using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Parts of the prefab
    public Rigidbody2D head, body, leftLeg, rightLeg, leftArm, rightArm;
    public Transform rightToe, leftToe;

    public PlayerController otherPlayer;

    // KeyCodes that when pressed will trigger this action
    public KeyCode right, left, jump, attack, block;

    private bool isGrounded = false;
    private bool isJumping = false;
    public LayerMask groundLayer; // The map - Layer for checking collisions with any of the map

    //Flip counting
    private float totalDegrees = 0;
    private Vector3 lastPoint;
    
    public bool hasGun = false;
    public gunScript currentGun;
    public GameObject meleePrefab;
    private meleeController tempMelee;

    //how many seconds we wait until raising the gun
    float standCount = 0.5f;
    //Seconds between melee attacks
    float meleeCount = 0.8f;
    //The rigidbody the gun is a child of
    public Rigidbody2D gunHand;

    public float health = 100;
    public Image healthBar;

    public bool paused;

    void Start()
    {
        disableParticles();
        /*
        head = transform.Find("head").GetComponent<Rigidbody2D>();
        rightArm = transform.Find("rightArm").GetComponent<Rigidbody2D>();
        leftArm = transform.Find("leftArm").GetComponent<Rigidbody2D>();
        rightLeg = transform.Find("rightLeg").GetComponent<Rigidbody2D>();
        leftLeg = transform.Find("leftLeg").GetComponent<Rigidbody2D>();
        rightToe = rightLeg.transform.Find("rightToe");
        leftToe = leftLeg.transform.Find("leftToe");
        */



        lastPoint = transform.TransformDirection(Vector3.right);
        lastPoint.y = 0;
        // Body can get stuck in itself without this
        Physics2D.IgnoreCollision(leftLeg.GetComponent<BoxCollider2D>(), leftArm.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(rightLeg.GetComponent<BoxCollider2D>(), rightArm.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(leftLeg.GetComponent<BoxCollider2D>(), body.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(rightLeg.GetComponent<BoxCollider2D>(), body.GetComponent<BoxCollider2D>());
    }

    void Update()
    {
        if (meleeCount <= 0.7)
        {
            disableParticles();
        }
        //Are the toes on the ground?
        isGrounded = (Physics2D.OverlapCircle(leftToe.position, 0.2f, groundLayer) || Physics2D.OverlapCircle(rightToe.position, 0.2f, groundLayer));
        //Don't take input or anything if the game is paused
        if (!paused)
        {
            meleeCount -= Time.deltaTime;
            standUp();
            HandleMovement();
            //raiseArm();

            //If the player's in the air, count the flips
            if (!isGrounded)
            {
                CountFlips();
            }
            else
            {
                totalDegrees = 0;
            }
        }
        healthBar.fillAmount = health/100;     
    }

    void HandleMovement()
    {
        //Forces added to head in order to control player movement
        if (Input.GetKeyDown(jump) && isJumping == false)
        {
            head.AddForce(new Vector2(0, 2500));
            isJumping = true;
        }
        if (Input.GetKeyDown(left))
        {
            head.AddForce(new Vector2(-500, 0));
        }
        if (Input.GetKeyDown(right))
        {
            head.AddForce(new Vector2(500, 0));
        }
        if (Input.GetKeyDown(attack))
        {
            doAttack();
        }
    }

    public int numberFlips
    {
        get
        {
            return ((int)totalDegrees) / 360;
        }
    }

    void CountFlips()
    {
        Transform tempBody = body.GetComponent<Transform>();
        Vector3 facing = tempBody.TransformDirection(Vector3.right);
        facing.y = 0;

        float angle = Vector3.Angle(lastPoint, facing);
        if (Vector3.Cross(lastPoint, facing).y < 0)
            angle *= -1;

        totalDegrees += angle;
        lastPoint = facing;

    }
    void standUp()
    {
        if (isGrounded)
        {
            standCount -= Time.deltaTime;
            isJumping = false;
            head.AddForce(new Vector2(0, 90));
            rightLeg.AddForce(new Vector2(0, -40));
            leftLeg.AddForce(new Vector2(0, -40));
            body.AddTorque(-body.angularVelocity);
        }
        else {
            standCount = 0.5f;
        }
    }
    void raiseArm() 
    {
        if (isGrounded && hasGun && standCount <= 0) {
            float currentAngle = gunHand.transform.localEulerAngles.z;
            Debug.Log(currentAngle);
            if ((currentAngle < 120 && gunHand == rightArm)||(currentAngle < 220 && gunHand == leftArm)) {
                float tempTorque = 90 - currentAngle;
                if (Mathf.Abs(tempTorque) > 90)
                {
                    tempTorque = 90 - currentAngle;
                }
                gunHand.AddTorque(tempTorque);
                gunHand.AddTorque(-gunHand.angularVelocity/10);
            }
        }
        else {

        }
    }
    void doAttack()
    {
        if (hasGun)
        {
            currentGun.fire();
        }
        else
        {
            if (meleeCount <= 0) {
                meleeCount = 0.8f;
                if (head.position.y > body.position.y)
                {
                    if (otherPlayer.body.transform.position.x < body.transform.position.x)
                    {
                        if (otherPlayer.head.transform.position.y < body.transform.position.y)
                        {
                            leftLeg.AddTorque(-120);
                            tempMelee = Instantiate(meleePrefab, leftLeg.position, body.transform.rotation).GetComponent<meleeController>();
                            //Kicks do double knockback
                            tempMelee.knockbackMult *= 2;
                            leftLeg.GetComponentInChildren<ParticleSystem>().Play();
                        }
                        else
                        {
                            leftArm.AddTorque(-120);
                            tempMelee = Instantiate(meleePrefab, leftArm.position, body.transform.rotation).GetComponent<meleeController>();
                            tempMelee.knockbackMult = (numberFlips + 1);
                            leftArm.GetComponentInChildren<ParticleSystem>().Play();
                        }
                    }
                    else if (otherPlayer.body.transform.position.x > body.transform.position.x)
                    {
                        if (otherPlayer.head.transform.position.y < body.transform.position.y)
                        {
                            rightLeg.AddTorque(120);
                            tempMelee = Instantiate(meleePrefab, rightLeg.position, body.transform.rotation).GetComponent<meleeController>();
                            //Double knockback for kick
                            tempMelee.knockbackMult *= 2;
                            rightLeg.GetComponentInChildren<ParticleSystem>().Play();
                        }
                        else
                        {
                            tempMelee = Instantiate(meleePrefab, rightArm.position, body.transform.rotation).GetComponent<meleeController>();
                            rightArm.AddTorque(120);
                            tempMelee.knockbackMult = (numberFlips + 1);
                            rightArm.GetComponentInChildren<ParticleSystem>().Play();
                        }
                    }
                }
                else
                {
                    if (otherPlayer.body.transform.position.x < body.transform.position.x)
                    {
                        if (otherPlayer.head.transform.position.y < body.transform.position.y)
                        {
                            rightArm.AddTorque(-120);
                            tempMelee = Instantiate(meleePrefab, rightArm.position, body.transform.rotation).GetComponent<meleeController>();
                            tempMelee.knockbackMult = (numberFlips + 1);
                            rightArm.GetComponentInChildren<ParticleSystem>().Play();
                        }
                        else
                        {
                            leftArm.AddTorque(-120);
                            tempMelee = Instantiate(meleePrefab, leftArm.position, body.transform.rotation).GetComponent<meleeController>();
                            tempMelee.knockbackMult = (numberFlips + 1);
                            leftArm.GetComponentInChildren<ParticleSystem>().Play();
                        }
                    }
                    else if (otherPlayer.body.transform.position.x > body.transform.position.x)
                    {
                        if (otherPlayer.head.transform.position.y < body.transform.position.y)
                        {
                            leftLeg.AddTorque(120);
                            tempMelee = Instantiate(meleePrefab, leftLeg.position, body.transform.rotation).GetComponent<meleeController>();
                            //Double knockback for kick
                            tempMelee.knockbackMult *= 2; 
                            leftLeg.GetComponentInChildren<ParticleSystem>().Play();
                        }
                        else
                        {
                            rightLeg.AddTorque(120);
                            tempMelee = Instantiate(meleePrefab, rightLeg.position, body.transform.rotation).GetComponent<meleeController>();

                            //Double knockback for kick
                            tempMelee.knockbackMult *= 2;

                            rightLeg.GetComponentInChildren<ParticleSystem>().Play();
                        }
                    }
                }
                tempMelee.owner = gameObject;
                tempMelee.knockbackMult += body.velocity.magnitude/10;
                tempMelee.knockbackMult += Mathf.Abs(body.angularVelocity)/200f;
            }
        }
    }
    void disableParticles()
    {
        leftLeg.GetComponentInChildren<ParticleSystem>().Stop();
        rightLeg.GetComponentInChildren<ParticleSystem>().Stop();
        leftArm.GetComponentInChildren<ParticleSystem>().Stop();
        rightArm.GetComponentInChildren<ParticleSystem>().Stop();
    }
}