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
        else
        {
            rb.AddForce(left * force);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tag = collision.gameObject.tag;
        if (CompareTag("ChangeDirection") && movingRight)
        {
            movingRight = false;
            gameObject.transform.eulerAngles = new Vector3(0, 180);
        }
        else
        {
            movingRight = true;
            gameObject.transform.eulerAngles = new Vector3(0, 0);
        }
    }
}
