using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpringPrintBTN : MonoBehaviour
{
    public GameObject Springprint;
    public Button yourButton;
    // Start is called before the first frame update
    void Start()
    {
        yourButton = gameObject.GetComponent<Button>();
        yourButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (Springprint.transform.GetChild(1).gameObject.activeInHierarchy)
        {
            Springprint.SetActive(false);
        }
    }

}
