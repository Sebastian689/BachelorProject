using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public SoundManager instance;

    public AudioSource audio;
    public AudioClip boost;
    public AudioClip jump;
    // Start is called before the first frame update

    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBoost()
    {
        audio.clip = boost;
        audio.Play();
        Debug.Log("Boost played");
    }

    public void PlayJump()
    {
        audio.clip = jump;
        audio.Play();
    }
}
