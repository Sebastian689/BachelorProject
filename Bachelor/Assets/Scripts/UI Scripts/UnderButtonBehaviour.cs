using System;
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
    [SerializeField] private GameObject GBS;
    [SerializeField] private GridBuildingSystem gridSystem;
    private string objectToPlace;

    // Start is called before the first frame update
    void Start()
    {
        GBS = GameObject.FindGameObjectWithTag("Grid");
        gridSystem = GBS.GetComponent<GridBuildingSystem>();
        
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        panel = overPanel;
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        //Activate placement

        if (embeddedObject != null)
        {
            gridSystem.testTransform = embeddedObject.transform;
            
            Debug.Log(embeddedObject);
        }
        
        panel.SetActive(false);
        overButton.Active = false;
    }

}
