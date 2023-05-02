using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accumulate : MonoBehaviour
{
    private static Accumulate instance;
    public GameObject overPanel;

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
        if (overPanel == null)
        {
            overPanel = GameObject.FindGameObjectWithTag("AdpPanel");
            overPanel.SetActive(false);
        }
        
    }

    public void ButtonClicked(Object buttonPrefab)
    {
        // Check if the button prefab is in the dictionary
        if (buttonUsage.ContainsKey(buttonPrefab))
        {
            // Increase the usage count for the clicked button
            buttonUsage[buttonPrefab]++;

            // Sort the buttons by usage count and get the most frequently used ones
            mostUsedButtons = buttonPrefabs.OrderByDescending(x => buttonUsage[x]).Take(numButtonsToDisplay).ToList();

            // Remove any existing buttons
            foreach (Transform child in overPanel.transform)
            {
                Destroy(child.gameObject);
            }

            int i = 0;
            // Create a new button for each most frequently used prefab
            foreach (Object usedPrefab in mostUsedButtons)
            {
                GameObject buttonObjectCopy = Instantiate(usedPrefab, overPanel.transform) as GameObject;

                // Get the button component on the new object
                Button buttonComponentCopy = buttonObjectCopy.GetComponent<Button>();

                // Add an onclick listener to the button component
                buttonComponentCopy.onClick.AddListener(() => ButtonClicked(usedPrefab));

                buttonObjectCopy.transform.localPosition = new Vector2(0, 150 - i * 100);

                i++;
            }
            overPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Button prefab not found in buttonUsage dictionary: " + buttonPrefab.name);
        }
    }

    public GameObject LowestOf(string[] names)
    {
        leastUsedButtons.Clear();
        
        string[] objectNames = names;
        leastUsedButtons = (from entry in buttonUsage
                            let gameObject = entry.Key as GameObject
                            where gameObject != null && objectNames.Contains(gameObject.name)
                            select gameObject).ToList();


        leastUsedButtons.OrderBy(x => buttonUsage[x]);


        if (leastUsedButtons.Count > 0)
        {
            return leastUsedButtons[0].GetComponent<UnderButtonBehaviour>().embeddedObject;
        }
        else
        {
            // Handle the case where no matching GameObjects were found
            Debug.LogWarning("No matching GameObjects found");
            return null;




        }
    }
}
