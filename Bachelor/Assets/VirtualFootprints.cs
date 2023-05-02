using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VirtualFootprints : MonoBehaviour
{
    private static VirtualFootprints instance;

    public int spring = 0;
    public int block = 0;
    public int ramp = 0;

    public GameObject SpringPrint;
    public GameObject BlockPrint;
    public GameObject RampPrint;
    public GameObject ReverseRampPrint;
    

    public GameObject SpringSquare;
    public GameObject RampSquare;
    public GameObject BlockSquare;

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
        BlockPrint.SetActive(false);
        RampPrint.SetActive(false);
        ReverseRampPrint.SetActive(false);

    }

    private void UpdateSquares()
    {
        spring = 0;
        ramp = 0;
        block = 0;
        if (SpringSquare == null)
        {
            if (GameObject.Find("SpringSquare") != null)
            {
                SpringSquare = GameObject.Find("SpringSquare");
                SpringSquare.SetActive(false);
            }
        }
        if (RampSquare == null)
        {
            if (GameObject.Find("RampSquare") != null)
            {
                RampSquare = GameObject.Find("RampSquare");
                RampSquare.SetActive(false);
            }
        }
        if (BlockSquare == null)
        {
            if (GameObject.Find("BlockSquare") != null)
            {
                BlockSquare = GameObject.Find("BlockSquare");
                BlockSquare.SetActive(false);
            }
        }
        if (SpringPrint.activeInHierarchy)
        {
            SpringPrint.SetActive(false);
        }
        if (BlockPrint.activeInHierarchy)
        {
            BlockPrint.SetActive(false);
        }
        if (RampPrint.activeInHierarchy)
        {
            RampPrint.SetActive(false);
        }
    }

    public void LogData(string name)
    {
        switch(name)
        {
            case "SpringPoint":
                spring++;
               if (spring == 3)
                {
                    if (SceneManager.GetActiveScene().name == "Level4")
                    {
                        AdpReverseRamp();
                    } else
                    {
                        AdpSpring();
                    }
                    
                }
               if (spring == 5)
                {
                    SpringSquare.SetActive(true);
                    if (SceneManager.GetActiveScene().name == "Level4")
                    {
                       AdpReverseRamp();
                    }
                    else
                    {
                       AdpSpring();
                    }
                    
                }
                
                break;
            case "BlockPoint":
                block++;
                if (block == 3)
                {
                    AdpBlock();
                }
                if (block == 5)
                {
                    BlockSquare.SetActive(true);
                    AdpBlock();
                }
                    
                
                break;
            case "RampPoint":
                ramp++;
                if (ramp == 3)
                {
                    AdpRamp();
                }
                if (ramp == 5)
                {
                    RampSquare.SetActive(true);
                    AdpRamp();
                }
                break;
        }
    }

    void AdpSpring()
    {
            SpringPrint.SetActive(true);
            SpringPrint.transform.GetChild(0).gameObject.SetActive(true);
            SpringPrint.transform.GetChild(1).gameObject.SetActive(false);
    }

    void AdpBlock()
    {
            BlockPrint.SetActive(true);
            BlockPrint.transform.GetChild(0).gameObject.SetActive(true);
            BlockPrint.transform.GetChild(1).gameObject.SetActive(false);
    }
    void AdpRamp()
    {
            RampPrint.SetActive(true);
            RampPrint.transform.GetChild(0).gameObject.SetActive(true);
            RampPrint.transform.GetChild(1).gameObject.SetActive(false);
    }
    void AdpReverseRamp()
    {
        ReverseRampPrint.SetActive(true);
        ReverseRampPrint.transform.GetChild(0).gameObject.SetActive(true);
        ReverseRampPrint.transform.GetChild(1).gameObject.SetActive(false);
    }
}
