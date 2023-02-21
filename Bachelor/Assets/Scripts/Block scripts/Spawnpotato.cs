using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpotato : MonoBehaviour
{

    public GameObject Bland;
    public GameObject Floaty;
    public GameObject Scared;
    float cooldown = 3; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && cooldown <= 0)
        {
            Instantiate(Bland, new Vector3(this.transform.position.x, this.transform.position.y+1, this.transform.position.z), Quaternion.identity);
            cooldown = 3;
        }else
        {
            cooldown -= Time.deltaTime;
        }
        
    }
}
