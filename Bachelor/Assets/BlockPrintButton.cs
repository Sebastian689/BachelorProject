using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockPrintButton : MonoBehaviour
{
    public GameObject Blockprint;
    public Button yourButton;
    // Start is called before the first frame update
    void Start()
    {
        yourButton = gameObject.GetComponent<Button>();
        yourButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (Blockprint.transform.GetChild(1).gameObject.activeInHierarchy)
        {
            Blockprint.SetActive(false);
        }
    }
}
