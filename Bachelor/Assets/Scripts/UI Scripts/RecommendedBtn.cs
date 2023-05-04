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

    public Image image;


 
   

  
}
