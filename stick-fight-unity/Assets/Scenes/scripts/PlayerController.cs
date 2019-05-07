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

    public bool isGrounded = false;
    public bool isJumping = false;
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
    public Text playerFlips;

    public bool paused;

    void Start()
    {
        lastPoint = transform.TransformDirection(Vector3.right);
        lastPoint.y = 0;
        // Body can get stuck in itself without this
        Physics2D.IgnoreCollision(leftLeg.GetComponent<BoxCollider2D>(), leftArm.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(rightLeg.GetComponent<BoxCollider2D>(), rightArm.GetComponent<BoxCollider2D>());
    }



    void Update()
    {
        //Are the toes on the ground?
        isGrounded = (Physics2D.OverlapCircle(leftToe.position, 0.2f, groundLayer) || Physics2D.OverlapCircle(rightToe.position, 0.2f, groundLayer));
        //These functions are pretty important
        if (!paused)
        {
            meleeCount -= Time.deltaTime;
            standUp();
            HandleMovement();
            raiseArm();

            if (!isGrounded)
            {
                   CountFlips();
                if (numberFlips == 0)
                {
                    playerFlips.enabled = false;
                }
                else
                {
                    Debug.Log(numberFlips.ToString());
                    Color textColor = new Color(Random.Range(75, 255), Random.Range(40, 100), Random.Range(70, 100), 100);
                    playerFlips.color = textColor;
                   // playerFlips.transform.localPosition = body.position;
                    playerFlips.enabled = true;
                    playerFlips.text = (numberFlips - 1).ToString() + "X";
                }
                   
                
            }
            else
            {
                playerFlips.enabled = false;
                totalDegrees = 0;
            }
        }
        healthBar.fillAmount = health/100;     
    }

    void HandleMovement()
    {
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
            //Debug.Log(currentAngle);
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
                tempMelee = Instantiate(meleePrefab, head.position, body.transform.rotation).GetComponent<meleeController>();
                tempMelee.owner = gameObject;

                tempMelee.damageMult = numberFlips+1;
                tempMelee.knockbackMult = numberFlips+1;

                if (otherPlayer.body.transform.position.x < body.transform.position.x) {
                    leftArm.AddTorque(-120);
                }
                else if (otherPlayer.body.transform.position.x > body.transform.position.x) {
                    rightArm.AddTorque(120);
                }
            }
        }
    }
}