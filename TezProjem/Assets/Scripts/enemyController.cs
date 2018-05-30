using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{

    public float enemySpeed;
    public GameObject enemyGraphic;

    Animator enemyAnim;
    bool canFlip = true;
    bool facingRight = true;
    float flipTime = 1f;
    float nextFlipChance = 0f;

    //Attack
    public float chargeTime;
    float startChargeTime;
    bool charging;
    Rigidbody2D enemyRB;

    void Start()
    {
        enemyAnim = GetComponentInChildren<Animator>();
        enemyRB = GetComponentInChildren<Rigidbody2D>();
    }


    void Update()
    {
        if (Time.time > nextFlipChance)
        {
            if (Random.Range(0, 10) >= 5) flipFacing();
            nextFlipChance = Time.time + flipTime;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (facingRight && other.transform.position.x < transform.position.x)
            {
                flipFacing();
            }else if (!facingRight && other.transform.position.x > transform.position.x)
            {
                flipFacing();
            }
            canFlip = false;
            charging = true;
            startChargeTime = Time.time + chargeTime;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (startChargeTime < Time.time)
            {
                if (!facingRight)
                {
                    enemyAnim.SetBool("isAngry", charging);
                    enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
                }else {
                    enemyAnim.SetBool("isAngry", charging);
                    enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
                }
                enemyAnim.SetBool("isAngry", charging);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canFlip = true;
            charging = false;
            enemyRB.velocity = new Vector2(0f, 0f);
            enemyAnim.SetBool("isAngry", charging);
        }
    }
    void flipFacing()
    {
        if (!canFlip) return;
        float facingX = enemyGraphic.transform.localScale.x;
        facingX *= -1f;
        enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y,enemyGraphic.transform.localScale.z);
        facingRight =! facingRight;
    }

}
