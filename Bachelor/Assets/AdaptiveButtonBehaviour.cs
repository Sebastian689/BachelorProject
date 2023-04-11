using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class AdaptiveButtonBehaviour : MonoBehaviour
{
    public int boostCounter;
    public int brakeCounter;
    public int reverseBoostCounter;
    public int jumpCounter;

    public Button ButtonA;
    public Button ButtonB;
    public Button ButtonC;
    public Button ButtonD;

    public RectTransform[] buttonTransforms;
    [SerializeField]
    Vector2[] positions = { new Vector2(0, -150), new Vector2(0, -50), new Vector2(0, 50), new Vector2(0, 150) };
    Vector2 posA = new Vector2(0, 150);
    Vector2 posB = new Vector2(0, 50);
    Vector2 posC = new Vector2(0, -50);
    Vector2 posD = new Vector2(0, -150);

    public int[] order = { 0, 0, 0, 0 };

    public Sorter sorter = new Sorter();
    
    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        //btn.onClick.AddListener(TaskOnClick);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ItemUsed(string name)
    {
        switch (name)
        {
            case "Boost":
                boostCounter++;
                
                break;
            case "Brake":
                brakeCounter++;
                
                break;
            case "LeftBoost":
                reverseBoostCounter++;
                
                break;
            case "Jump":
                jumpCounter++;
                
                break;
        }


    }

    public void TaskOnClick()
    {

        // if (boostCounter > brakeCounter && brakeCounter > reverseBoostCounter && reverseBoostCounter > jumpCounter)
        // {
        //     ButtonA.GetComponent<RectTransform>().anchoredPosition = posA;
        //     ButtonB.GetComponent<RectTransform>().anchoredPosition = posB;
        //     ButtonC.GetComponent<RectTransform>().anchoredPosition = posC;
        //     ButtonD.GetComponent<RectTransform>().anchoredPosition = posD;
        // }
        // if (boostCounter > reverseBoostCounter && reverseBoostCounter > brakeCounter && brakeCounter > jumpCounter)
        // {
        //     ButtonA.GetComponent<RectTransform>().anchoredPosition = posA;
        //     ButtonC.GetComponent<RectTransform>().anchoredPosition = posB;
        //     ButtonB.GetComponent<RectTransform>().anchoredPosition = posC;
        //     ButtonD.GetComponent<RectTransform>().anchoredPosition = posD;
        // }
        // if (boostCounter > jumpCounter && jumpCounter > brakeCounter && brakeCounter > reverseBoostCounter)
        // {
        //     ButtonA.GetComponent<RectTransform>().anchoredPosition = posA;
        //     ButtonD.GetComponent<RectTransform>().anchoredPosition = posB;
        //     ButtonB.GetComponent<RectTransform>().anchoredPosition = posC;
        //     ButtonC.GetComponent<RectTransform>().anchoredPosition = posD;
        // }
        var buttonPositions = new[] { posA, posB, posC, posD };
        var buttonOrder = new[] { "ABCD", "ACBD", "ADBC", "BACD", "BCAD", "BDAC", "CABD", "CBAD", "CDAB", "DABC", "DBAC", "DCAB" };
        var counters = new[] { boostCounter, brakeCounter, reverseBoostCounter, jumpCounter };

        var maxCounterIndex = 0;
        for (int i = 1; i < counters.Length; i++)
        {
            if (counters[i] > counters[maxCounterIndex])
            {
                maxCounterIndex = i;
            }
        }

        if (buttonOrder[maxCounterIndex] != null)
        {
            for (int i = 0; i < buttonOrder[maxCounterIndex].Length; i++)
            {
                var buttonIndex = buttonOrder[maxCounterIndex][i] - 'A';
                Button button = null;

                switch (buttonIndex)
                {
                    case 0:
                        button = ButtonA;
                        break;
                    case 1:
                        button = ButtonB;
                        break;
                    case 2:
                        button = ButtonC;
                        break;
                    case 3:
                        button = ButtonD;
                        break;
                    default:
                        throw new InvalidOperationException($"Invalid button index {buttonIndex}");
                }

                button.GetComponent<RectTransform>().anchoredPosition = buttonPositions[i];
            }
        }




        // Array.Sort(order, buttonTransforms);
        //
        // for (int i = 0; i < buttonTransforms.Length; i++)
        // {
        //     buttonTransforms[i].anchoredPosition = positions[i];
        // }
    }
}

public class Sorter
{
    public int boostCount;
    public int brakeCount;
    public int reverseBoostCount;
    public int jumpCount;
}
