using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualFootprints : MonoBehaviour
{
    private static VirtualFootprints instance;

    public int spring = 0;
    public int block = 0;
    public int ramp = 0;

    public GameObject SpringPrint;

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
        SpringPrint.SetActive(false);
    }

    public void LogData(string name)
    {
        switch(name)
        {
            case "SpringPoint":
                spring++;
                AdpSpring(spring);
                break;
            case "BlockPoint":
                block++;
                break;
            case "RampPoint":
                ramp++;
                break;
        }
    }

    void AdpSpring(int counter)
    {
        if (counter > 3)
        {
            SpringPrint.SetActive(true);
            SpringPrint.transform.GetChild(0).gameObject.SetActive(true);
            SpringPrint.transform.GetChild(1).gameObject.SetActive(false);
            spring = 0;
        }
    }
}
