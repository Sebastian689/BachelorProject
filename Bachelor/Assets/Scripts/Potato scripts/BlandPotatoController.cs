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
    float boostForce = 300f;
    public float maxVelocity = 3f;
    Vector3 direction = new Vector3(1,0,0);
    bool finished = false;
    public GameManager GM;
    public GameObject go;

    private int level;
    public SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.FindGameObjectWithTag("GameManager");
        GM = go.GetComponent<GameManager>();

        rb = this.GetComponent<Rigidbody2D>();
        soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
        //col = this.GetComponent<Collider>();
        

        level = GM.level;
    }

    

    // Update is called once per frame
    void Update()
    {
        if(cooldown <= 0 && finished != true)
        {
            GM.BeginTimer();

            rb.AddForce(direction * force);
        } else if(finished == true)
        {
            Debug.LogWarning("Else");
            rb.velocity = new Vector3(0, 0, 0);
            
        }
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
        string otherTag = collision.gameObject.tag;

        switch (otherTag)
        {
        

            case "Death":
                InitiateDeath(0);
            break;

            case "Death1":
                InitiateDeath(1);
            break;

            case "NormalSpeed":
                force = 0.1f;
                Debug.Log("Normal speed");
            break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string otherTag = other.gameObject.tag;

        switch (otherTag)
        {

            case "Goal":
                Debug.LogWarning("I finished");
                finished = true;
                GM.blandFinish = true;
                Debug.Log("Finished");

                break;

            case "Jump":
                rb.AddForce( new Vector3(0, 1f * jumpForce, 0));
                soundManager.PlayJump();
                break;

            case "Stop":
                force = 0f;
                Debug.Log("Force 0");
                break;
            
            case "Boost":
                rb.AddForce(new Vector3(1, 0, 0) * boostForce);
                soundManager.PlayBoost();
                break;
            
            case "LeftBoost":
                rb.AddForce(new Vector3(-1, 0, 0) * boostForce);
                break;
            
            case "Brake":
                rb.velocity = new Vector3(0, 0, 0);
                cooldown = 1;
                break;
            case "coin":
                coinBehaviour cb = other.gameObject.GetComponent<coinBehaviour>();
                cb.COIN();
                break;
        }
    }

    private void InitiateDeath(int i)
    {
        if (i == 1)
        {
          GameObject.FindGameObjectWithTag("StartBlock").GetComponent<SpawnPotatoLevel1>().Invoke("SpawnPotato", 3);
        }
        else
        {
          GameObject.FindGameObjectWithTag("StartBlock").GetComponent<Spawnpotato>().Invoke("SpawnPotato", 3);
        }
        //Oh no
        
        GM.RecieveDeath();
        Destroy(this.gameObject);
        Debug.LogWarning("I died");
        
    }

  
}
