using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnderButtonBehaviour : MonoBehaviour
{

    public Button yourButton;
    public GameObject overPanel;
    GameObject panel;
    public GameObject embeddedObject;
    public MainButtonBehaviour overButton;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        panel = overPanel;
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");

        //Activate placement
        panel.SetActive(false);
        overButton.Active = false;
    }

}
