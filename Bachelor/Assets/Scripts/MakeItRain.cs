using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MakeItRain : MonoBehaviour
{

    public float cooldown;
    public GameObject Bland;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = Random.Range(1, 6);
    }

    // Update is called once per frame
    void Update()
    {
        if ( cooldown <= 0)
        {
            Instantiate(Bland, new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), Quaternion.identity);
            cooldown = 2f;
        } else
        {
            cooldown -= Time.deltaTime;
        }
    }
}
