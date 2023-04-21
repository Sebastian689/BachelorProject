using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpringPrint : MonoBehaviour
{
    public Button yourButton;
    public GameObject Springprint;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (Springprint.activeInHierarchy)
        {
            Springprint.transform.GetChild(0).gameObject.SetActive(false);
            Springprint.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
