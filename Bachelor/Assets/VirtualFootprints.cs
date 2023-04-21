using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualFootprints : MonoBehaviour
{
    private static VirtualFootprints instance;

    public int spring = 0;
    public int block = 0;
    public int ramp = 0;

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

    public void LogData(string name)
    {
        switch(name)
        {
            case "SpringPrint":
                spring++;
                break;
            case "BlockPrint":
                block++;
                break;
            case "RampPrint":
                ramp++;
                break;
        }
    }
}
