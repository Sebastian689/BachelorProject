using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserProfile : MonoBehaviour
{
    public Accumulate accumulate;
    public GameObject UserProfileWindow;

    private bool profile;
    
    // Start is called before the first frame update
    void Start()
    {
        UserProfileWindow = GameObject.FindGameObjectWithTag("UserProfile");
        accumulate = GameObject.FindGameObjectWithTag("Accumulate").GetComponent<Accumulate>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("User has experience = " + profile);
        if (profile && accumulate.deaths >= 10 || profile && accumulate.timer >= 120.0f)
        {
            profile = false;
        }
    }

    public void Experienced()
    {
        UserProfileWindow.SetActive(false);
        profile = true;
    }
    
    public void NoExperienced()
    {
        UserProfileWindow.SetActive(false);
        profile = false;
    }
    
}
