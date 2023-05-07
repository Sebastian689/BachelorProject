using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class inactiveRecommended : MonoBehaviour
{
    public bool value = false;
    public GameObject panel;
    
    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.FindGameObjectWithTag("Recommended Panel");
        Invoke("SetActiveFalse", 0.1f);
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

    public void SetActiveFalse()
    {
        panel.SetActive(false);
    }

    public void NewLevel()
    {
        
        value = false;
        SetChildValue();
    }
}
