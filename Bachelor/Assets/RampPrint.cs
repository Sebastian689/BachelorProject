using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RampPrint : MonoBehaviour
{
    public Button myButton;
    public GameObject Rampprint;
    // Start is called before the first frame update
    void Start()
    {
        myButton = gameObject.GetComponent<Button>();
        myButton.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        if (Rampprint.activeInHierarchy)
        {
            Rampprint.transform.GetChild(0).gameObject.SetActive(false);
            Rampprint.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
