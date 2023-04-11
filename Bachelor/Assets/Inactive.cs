using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inactive : MonoBehaviour
{
    bool value = false;
    // Start is called before the first frame update
    void Start()
    {
        
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
        }
        else
        {
            value = true;
        }
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }
}
