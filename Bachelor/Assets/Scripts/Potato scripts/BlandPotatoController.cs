using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlandPotatoController : MonoBehaviour
{
    Rigidbody2D rb;
    //new Collider col;
    float cooldown = 3;
    public float force;
    float jumpForce = 500f;
    public float maxVelocity = 3f;
    Vector3 direction = new Vector3(1,0,0);
    bool finished = false;
    public GameManager GM;
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.FindGameObjectWithTag("GameManager");
        GM = go.GetComponent<GameManager>();

        rb = this.GetComponent<Rigidbody2D>();
        //col = this.GetComponent<Collider>();
    }

    

    // Update is called once per frame
    void Update()
    {
        if(cooldown <= 0 && finished != true)
        {
            if(GM.timerHasBegun == false)
            {
                GM.BeginTimer();
            }

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

            case "NormalSpeed":
                force = 0.1f;
                Debug.Log("Normal speed");
            break;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Stop")
        {
            force = 0f;
            Debug.Log("Force 0");
            
        }
    }

    private void InitiateDeath()
    {
        //Oh no
        GM.RecieveDeath();
        Debug.LogWarning("I died");
        Destroy(this.gameObject);
    }
}
