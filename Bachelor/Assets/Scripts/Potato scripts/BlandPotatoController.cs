using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlandPotatoController : MonoBehaviour
{
    new Rigidbody rb;
    //new Collider col;
    float cooldown = 3;
    float force = 5f;
    Vector3 direction = new Vector3(-1,0,0); 
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        //col = this.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown <= 0)
        {
            rb.AddForce(direction * force);
        } else
        {
            cooldown -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        tag = collision.gameObject.tag;

        switch (tag)
        {
            case "Jump":
                //DoSomething
            break;
        }
    }
}
