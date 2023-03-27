using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlandPotatoController : MonoBehaviour
{
    Rigidbody2D rb;
    //new Collider col;
    float cooldown = 3;
    public float force;
    float jumpForce = 1300f;
    float boostForce = 500f;
    public float maxVelocity = 3f;
    Vector3 direction = new Vector3(1,0,0);
    bool finished = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        tag = collision.gameObject.tag;

        switch (tag)
        {
            case "Goal":
                finished = true;
                Debug.Log("Finished");
            break;

            case "Death":
                InitiateDeath();
            break;

            case "Brake":
                rb.velocity = new Vector3(0, 0, 0);
                cooldown = 1;
            break;

            case "NormalSpeed":
                force = 0.1f;
                Debug.Log("Normal speed");
            break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        tag = other.gameObject.tag;

        switch (tag)
        {
            case "Jump":
                rb.AddForce( new Vector3(0, 1f * jumpForce, 0));
                break;

            case "Stop":
                force = 0f;
                Debug.Log("Force 0");
                break;
            
            case "Boost":
                rb.AddForce(new Vector3(1, 0, 0) * boostForce);
                break;
        }
    }

    private void InitiateDeath()
    {
        //Oh no
        Destroy(this.gameObject);
    }
}
