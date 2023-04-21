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
    
    public GameObject boost;
    public GameObject revBoost;
    public GameObject spring;
    public GameObject brake;
    public GameObject block;
    public GameObject blockL;
    public GameObject BlockR;
    public GameObject ramp;
    public GameObject revRamp;

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
        else {

            /* switch (SceneManager.GetActiveScene().name)
             {
                 case ("Level2"):
                     //run logic
                     embeddedObject = ChooseLowest(spring, block, brake);
                 break;
                 case ("Level3"):
                     //run logic
                     embeddedObject = ChooseLowest(blockL, revBoost, revRamp);
                 break;
                 case ("Level4"):
                     //run logic
                     embeddedObject = ChooseLowest(ramp, block, revBoost);
                 break;
                 case ("Level5"):
                     //run logic
                     embeddedObject = ChooseLowest(blockL, blockR, ramp);
                 break;
             }
            */
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

    void ChooseLowest(GameObject one, GameObject two, GameObject three)
    {

        // int a = one.int;
        // int b = two.int;
        // int c = three.int;

        // if (a < b && a != b){
        //     if (a < c && a != c){
        //          return one.embeddedObject;
        //     } else if (a == c){
        //     }else {
        //              return three.embeddedObject;
        //     }
        // } else if (b < c && b != c && b != a){
        //      return two.embeddedObject;
        // } else {
        //          return three..embeddedObject
        // }
    }

}
