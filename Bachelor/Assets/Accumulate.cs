using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accumulate : MonoBehaviour
{
    private static Accumulate instance;
    //public GameObject overPanel;

    [SerializeField] private Object[] buttonPrefabs;
    [SerializeField] private int numButtonsToDisplay = 4;
    public Dictionary<Object, int> buttonUsage = new Dictionary<Object, int>();
    private List<Object> mostUsedButtons = new List<Object>();
     private List<GameObject> leastUsedButtons = new List<GameObject>();
    
    public int deaths;
    public float score;
    public float timer;
    public int clicks;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    private void Start()
    {
        foreach (Object prefab in buttonPrefabs)
        {
            buttonUsage.Add(prefab, 0);
            Debug.Log("Ran");
        }
    }

    private void Update()
    {
        //if (overPanel == null)
        //{
        //    overPanel = GameObject.FindGameObjectWithTag("AdpPanel");
        //    overPanel.SetActive(false);
        //}
        
    }

    
    
}
