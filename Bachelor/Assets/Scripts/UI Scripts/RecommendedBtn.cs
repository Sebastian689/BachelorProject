using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecommendedBtn : MonoBehaviour
{
    public Button yourButton;
 
    public GameObject embeddedObject;
    public string[] objectNames;
    public GameObject boost;
    public GameObject revBoost;
    public GameObject spring;
    public GameObject brake;
    public GameObject block;
    public GameObject blockL;
    public GameObject blockR;
    public GameObject ramp;
    public GameObject revRamp;
    public Accumulate accum;

    [SerializeField] private GameObject GBS;
    [SerializeField] private GridBuildingSystem gridSystem;
    private string objectToPlace;

    private GameObject one;
    private GameObject two;
    private GameObject three;


    // Start is called before the first frame update
    void Start()
    {
        objectNames = new string[] { "placeholder" };
        GBS = GameObject.FindGameObjectWithTag("Grid");
        gridSystem = GBS.GetComponent<GridBuildingSystem>();
        accum = GameObject.FindGameObjectWithTag("Accumulate").GetComponent<Accumulate>();

        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        switch (SceneManager.GetActiveScene().name)
        {
            case ("Level1"):
                this.gameObject.SetActive(false);
                break;
        }
    }

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {

            this.gameObject.SetActive(false);
        }
       

    }

    
    public void Preset() 
    {
        this.gameObject.SetActive(true);
         switch (SceneManager.GetActiveScene().name)
               {
                   case ("Level1"):
                //run logic
                one = spring;
                two = block;
                three = brake;
                string[] objectNames = new string[] { one.name, two.name, three.name };
                       embeddedObject = accum.LowestOf(objectNames);
                   break;
                   case ("Level2"):
                //run logic
                one = blockL;
                two = revBoost;
                three = revRamp;
                string[] objectNamesTwo = new string[] { one.name, two.name, three.name };
                embeddedObject = accum.LowestOf(objectNamesTwo);
                break;
                   case ("Level3"):
                //run logic
                one = ramp;
                two = block;
                three = revBoost;
                string[] objectNamesThree = new string[] { one.name, two.name, three.name };
                embeddedObject = accum.LowestOf(objectNamesThree);
                break;
                   case ("Level4"):
                //run logic
                one = blockL;
                two = blockR;
                three = ramp;
                string[] objectNamesFour = new string[] { one.name, two.name, three.name };
                embeddedObject = accum.LowestOf(objectNamesFour);
                break;
               }
              

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

     
    }

  
}
