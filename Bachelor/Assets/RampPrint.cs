using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RampPrint : MonoBehaviour
{
    public Button myButton;
    public GameObject Rampprint;
    public GameObject ReverseRampPrint;
    [SerializeField] bool hasRecommended;
    // Start is called before the first frame update
    void Start()
    {
        myButton = gameObject.GetComponent<Button>();
        myButton.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        if (hasRecommended)
        {
            if (Rampprint.activeInHierarchy) Rampprint.SetActive(false);
            if (ReverseRampPrint.activeInHierarchy) ReverseRampPrint.SetActive(false);
            hasRecommended = false;
        }
        if (Rampprint.activeInHierarchy)
        {
            Rampprint.transform.GetChild(0).gameObject.SetActive(false);
            Rampprint.transform.GetChild(1).gameObject.SetActive(true);
            hasRecommended = true;
        }
        if (ReverseRampPrint.activeInHierarchy)
        {
            ReverseRampPrint.transform.GetChild(0).gameObject.SetActive(false);
            ReverseRampPrint.transform.GetChild(1).gameObject.SetActive(true);
            hasRecommended = true;
        }
    }
}
