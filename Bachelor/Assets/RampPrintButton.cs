using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RampPrintButton : MonoBehaviour
{
    public GameObject Rampprint;
    public Button yourButton;
    // Start is called before the first frame update
    void Start()
    {
        yourButton = gameObject.GetComponent<Button>();
        yourButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (Rampprint.transform.GetChild(1).gameObject.activeInHierarchy)
        {
            Rampprint.SetActive(false);
        }
    }
}
