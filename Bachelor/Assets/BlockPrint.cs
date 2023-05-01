using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockPrint : MonoBehaviour
{
    public Button yourButton;
    public GameObject Blockprint;
    // Start is called before the first frame update
    void Start()
    {
        yourButton = gameObject.GetComponent<Button>();
        yourButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (Blockprint.activeInHierarchy)
        {
            Blockprint.transform.GetChild(0).gameObject.SetActive(false);
            Blockprint.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
