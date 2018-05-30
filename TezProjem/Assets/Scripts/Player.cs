using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //movement
    public float maxSpeed;
    //jumping
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    Rigidbody2D myRigidBody;
    Animator myAnim;
    bool facingRight;
    //shooting
    bool attackAir;
    public Transform gunTip;
    public GameObject bullet;
    public float fireRate = 0.1f;
    float nextFire = 0f;
    //Particle
    public ParticleEmitter muzzle;


    void Start()
    {
        muzzle.emit = false;
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        attackAir = true;
        facingRight = true;
    }
    void Update()
    {

        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRigidBody.AddForce(new Vector2(0, jumpHeight));
        }



        //player shooting
        // Mouse Sol Click veya J tuşu = Ateş eder , Escape tuşu = Zıplar , A D ve Sol Sağ yön tuşları hareket ettirir.
        if (Input.GetAxisRaw("Fire1") > 0 || Input.GetKeyDown(KeyCode.J))
        {
            muzzle.emit = true;
            fireBullet();
            myAnim.SetTrigger("attack");
        }
        else if (Input.GetAxisRaw("Fire1") > 0 && grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("attackAir", true);
        }else if(Input.GetKeyDown(KeyCode.J) && grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("attackAir", true);
        }
        else
        {
            muzzle.emit = false;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);
        myAnim.SetFloat("verticalSpeed", myRigidBody.velocity.y);
        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));
        myRigidBody.velocity = new Vector2(move * maxSpeed, myRigidBody.velocity.y);

        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void fireBullet()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));

            }
            else if (!facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
    }
}