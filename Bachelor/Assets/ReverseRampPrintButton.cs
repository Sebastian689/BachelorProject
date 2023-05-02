using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReverseRampPrintButton : MonoBehaviour
{
    public GameObject ReverseRampprint;
    public Button yourButton;
    // Start is called before the first frame update
    void Start()
    {
        yourButton = gameObject.GetComponent<Button>();
        yourButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (ReverseRampprint.transform.GetChild(1).gameObject.activeInHierarchy)
        {
            ReverseRampprint.SetActive(false);
        }
    }
}
