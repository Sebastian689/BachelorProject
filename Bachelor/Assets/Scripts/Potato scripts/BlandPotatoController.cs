using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlandPotatoController : MonoBehaviour
{
    new Rigidbody rb;
    //new Collider col;
    float cooldown = 3;
    float force = 2f;
    float jumpForce = 500f;
    float maxVelocity = 3f;
    Vector3 direction = new Vector3(1,0,0);
    bool finished = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        //col = this.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown <= 0 && finished != true)
        {
            rb.AddForce(direction * force);
        } /*else if(finished == true)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }*/
        else
        {
            cooldown -= Time.deltaTime;
        }

        if(rb.velocity.sqrMagnitude > maxVelocity)
        {
            rb.velocity *= 0.99f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        tag = collision.gameObject.tag;

        switch (tag)
        {
            case "Jump":
                rb.AddForce( new Vector3(0, 1, 0) * jumpForce);
            break;

            case "Goal":
                finished = true;
            break;

            case "Death":
                InitiateDeath();
            break;

            case "Boost":
                rb.AddForce(new Vector3(1, 0, 0) * jumpForce);
            break;

            case "Brake":
                rb.velocity = new Vector3(0, 0, 0);
                cooldown = 1;
            break;
        }

    }

    private void InitiateDeath()
    {
        //Oh no
        Destroy(this.gameObject);
    }
}
