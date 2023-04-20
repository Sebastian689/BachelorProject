using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Rigidbody2D rb;
    public float force;
    Vector3 right = new Vector3(1, 0, 0);
    Vector3 left = new Vector3(-1, 0, 0);
    public bool movingRight = true;
    public bool movingLeft = false;
    public float maxVelocity = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.sqrMagnitude > maxVelocity)
        {
            rb.velocity *= 0.99f;
        }
        if (movingRight)
        {
            rb.AddForce(right * force);
        }
        else if (movingLeft)
        {
            rb.AddForce(left * force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Blocker"))
        {
            if (movingRight)
            {
                movingRight = false;
                movingLeft = true;
                gameObject.transform.eulerAngles = new Vector3(0, 180);
            }
            else
            {
                movingLeft = false;
                movingRight = true;
                gameObject.transform.eulerAngles = new Vector3(0, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //tag = collision.gameObject.tag;
        if (collision.gameObject.CompareTag("MonsterGoLeft"))
        {
            movingRight = false;
            movingLeft = true;
            rb.velocity *= 0f;
            gameObject.transform.eulerAngles = new Vector3(0, 180);
        }
        if (collision.gameObject.CompareTag("MonsterGoRight"))
        {
            movingRight = true;
            movingLeft = false;
            rb.velocity *= 0f;
            gameObject.transform.eulerAngles = new Vector3(0, 0);
        }

        if (collision.gameObject.CompareTag("BlockLeft"))
        {
            movingRight = false;
            movingLeft = true;
            rb.velocity *= 0f;
            gameObject.transform.eulerAngles = new Vector3(0, 180);
        }
        if (collision.gameObject.CompareTag("BlockRight"))
        {
            movingRight = true;
            movingLeft = false;
            rb.velocity *= 0f;
            gameObject.transform.eulerAngles = new Vector3(0, 0);
        }
    }
}
