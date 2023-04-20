using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inactive : MonoBehaviour
{
    public bool value = false;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
       panel = GameObject.FindGameObjectWithTag("AdpPanel");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetChildValue()
    {
        if (value)
        {
            value = false;
            panel.SetActive(value);
        }
        else
        {
            value = true;
            panel.SetActive(value);
        }
        
    }
}
