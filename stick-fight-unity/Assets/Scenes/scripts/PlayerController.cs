using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    // Parts of the prefab
    public Rigidbody2D head, body, leftLeg, rightLeg, leftArm, rightArm;
    public Transform rightToe, leftToe;

    public PlayerController otherPlayer;

    // KeyCodes that when pressed will trigger this action
    public KeyCode right, left, jump, attack;

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
    public Text playerFlips;

    private Vector3 headPos;
    private Vector2 headScreenPos;

    public Camera camera;

    public Transform directionalIndicator;

    public GameObject head1, body1, rightarm1, leftarm1, rightleg1, leftleg1;
    public GameObject head2, body2, rightarm2, leftarm2, rightleg2, leftleg2;

    public bool paused;

    public bool won = false;

    public float speed;

    void Awake() {
        disableParticles();
    }

    

    void Start()
    {
        pullControls();
        changeColor();
        disableParticles();

        lastPoint = transform.TransformDirection(Vector3.right);
        lastPoint.y = 0;
        // Body can get stuck in itself without this
        Physics2D.IgnoreCollision(leftLeg.GetComponent<BoxCollider2D>(), leftArm.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(rightLeg.GetComponent<BoxCollider2D>(), rightArm.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(leftLeg.GetComponent<BoxCollider2D>(), body.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(rightLeg.GetComponent<BoxCollider2D>(), body.GetComponent<BoxCollider2D>());
    }

    /*public static Vector3 GetScreenPosition(Transform transform, Canvas canvas, Camera cam)
    {
        Vector3 pos;
        float width = canvas.GetComponent<RectTransform>().sizeDelta.x;
        float height = canvas.GetComponent<RectTransform>().sizeDelta.y;
        float x = Camera.main.WorldToScreenPoint(transform.position).x / Screen.width;
        float y = Camera.main.WorldToScreenPoint(transform.position).y / Screen.height;
        pos = new Vector3(width * x - width / 2, y * height - height / 2);
        return pos;
    }*/

    private bool isOffScreen()
    {
        if (head.position.y > 13)
        {
            return true;
        }
        else if (head.position.x < -23)
        {
            return true;
        } else if (head.position.x > 23)
        {
            return true;
        }
        else return false;
    }

    

    void Update()
    {
        if (meleeCount <= 0.7 && !won)
        {
            disableParticles();
        }
        else if (won)
        {
            enableParticles();
        }
        if (otherPlayer.won)
        {
            health = 0;
            Destroy(head.GetComponent<HingeJoint2D>());
            Destroy(rightArm.GetComponent<HingeJoint2D>());
            Destroy(leftArm.GetComponent<HingeJoint2D>());
            Destroy(rightLeg.GetComponent<HingeJoint2D>());
            Destroy(leftLeg.GetComponent<HingeJoint2D>());
            Destroy(this);
        }
        //Are the toes on the ground?
        isGrounded = (Physics2D.OverlapCircle(leftToe.position, 0.2f, groundLayer) || Physics2D.OverlapCircle(rightToe.position, 0.2f, groundLayer));
        //Don't take input or anything if the game is paused

        if (isOffScreen())
        {
            Vector2 direction = new Vector2(head.position.x, head.position.y);
            directionalIndicator.up = direction;
            directionalIndicator.GetComponent<Renderer>().enabled = true;
        } else directionalIndicator.GetComponent<Renderer>().enabled = false;


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
                if (numberFlips == 0)
                {
                    playerFlips.enabled = false;
                }
                else
                {
                    headPos = head.position;
                    headScreenPos = Camera.main.WorldToScreenPoint(headPos);
                    headScreenPos = new Vector2(headScreenPos.x, headScreenPos.y + 30);
                    playerFlips.GetComponent<Transform>().position = headScreenPos;
                    playerFlips.enabled = true;
                    playerFlips.text = numberFlips.ToString() + "X" + "!";
                    
                }
                   
                
            }
            else
            {
                playerFlips.enabled = false;
                totalDegrees = 0;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pullControls();
                changeColor();
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
            if (isGrounded) 
            {
                body.AddForce(new Vector2(-500, 0));
                head.AddForce(new Vector2(0, 100));
            }
            else 
            {
                head.AddForce(new Vector2(-500, 0));
            }
        }
        if (Input.GetKeyDown(right))
        {
            if (isGrounded) 
            {
                body.AddForce(new Vector2(500, 0));
                head.AddForce(new Vector2(0, 100));
            }
            else 
            {
                head.AddForce(new Vector2(500, 0));
            }
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
                if (head.position.y > body.position.y)
                {
                    if (otherPlayer.body.transform.position.x < body.transform.position.x)
                    {
                        if (otherPlayer.head.transform.position.y < body.transform.position.y)
                        {
                            leftLeg.AddTorque(-120);
                            tempMelee = Instantiate(meleePrefab, leftLeg.position, body.transform.rotation).GetComponent<meleeController>();
                            tempMelee.damageMult = (numberFlips + 1);
                            tempMelee.damageMult *= 2;
                            //Kicks do double knockback
                            tempMelee.knockbackMult = (numberFlips + 1);
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
                            
                            tempMelee.damageMult = (numberFlips + 1);
                            tempMelee.damageMult *= 2;
                            //Double knockback for kick
                            tempMelee.knockbackMult = (numberFlips + 1);
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
                    if (tempMelee.knockbackMult > 15)
                    {
                        tempMelee.knockbackMult = 15;
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

                            
                            tempMelee.damageMult = (numberFlips + 1);
                            tempMelee.damageMult *= 2;

                            tempMelee.knockbackMult = (numberFlips + 1);
                            //Double knockback for kick
                            tempMelee.knockbackMult *= 2; 
                            leftLeg.GetComponentInChildren<ParticleSystem>().Play();
                        }
                        else
                        {
                            rightLeg.AddTorque(120);
                            tempMelee = Instantiate(meleePrefab, rightLeg.position, body.transform.rotation).GetComponent<meleeController>();

                            
                            tempMelee.damageMult = (numberFlips + 1);
                            tempMelee.damageMult *= 2;

                            tempMelee.knockbackMult = (numberFlips + 1);
                            //Double knockback for kick
                            tempMelee.knockbackMult *= 2;

                            rightLeg.GetComponentInChildren<ParticleSystem>().Play();
                        }
                    }
                }
                tempMelee.owner = gameObject;
                tempMelee.knockbackMult += body.velocity.magnitude/7;
                tempMelee.knockbackMult += Mathf.Abs(body.angularVelocity)/150f;

                tempMelee.damageMult += body.velocity.magnitude/10;
                tempMelee.damageMult += Mathf.Abs(body.angularVelocity)/200f;
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
    public void enableParticles()
    {
        leftLeg.GetComponentInChildren<ParticleSystem>().Play();
        rightLeg.GetComponentInChildren<ParticleSystem>().Play();
        leftArm.GetComponentInChildren<ParticleSystem>().Play();
        rightArm.GetComponentInChildren<ParticleSystem>().Play();
    }
    public void pullControls()
    {
        Debug.Log("Pulling Controls");
        if (gameObject.name == "player1")
        {
            right = GlobalController.Instance.right1;
            left = GlobalController.Instance.left1;
            jump = GlobalController.Instance.jump1;
            attack = GlobalController.Instance.attack1;
        }
        else if (gameObject.name == "player2")
        {
            right = GlobalController.Instance.right2;
            left = GlobalController.Instance.left2;
            jump = GlobalController.Instance.jump2;
            attack = GlobalController.Instance.attack2;
        }
    }
    void changeColor()
    {
        GameObject[] player1 = new GameObject[] { head1, body1, rightarm1, leftarm1, rightleg1, leftleg1 };
        GameObject[] player2 = new GameObject[] { head2, body2, rightarm2, leftarm2, rightleg2, leftleg2 };
        for (int i = 0; i < player1.Length; i++)
        {
            Debug.Log("Coloring Character");
            player1[i].GetComponent<SpriteRenderer>().color = GlobalController.Instance.player1Color;
        }
        for (int i = 0; i < player2.Length; i++)
        {
            player2[i].GetComponent<SpriteRenderer>().color = GlobalController.Instance.player2Color;
        }
    }
    
}