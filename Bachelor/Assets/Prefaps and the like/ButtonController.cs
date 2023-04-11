using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject overPanel;
    [SerializeField] private Object[] buttonPrefabs;
    [SerializeField] private int numButtonsToDisplay = 4;
    private Dictionary<Object, int> buttonUsage = new Dictionary<Object, int>();
    private List<Object> mostUsedButtons = new List<Object>();

    private void Start()
    {
        
        // Add all button prefabs to the usage dictionary
        foreach (Object prefab in buttonPrefabs)
        {
            buttonUsage.Add(prefab, 0);
        }

        gameObject.SetActive(false);
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
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            int i = 0;
            // Create a new button for each most frequently used prefab
            foreach (Object usedPrefab in mostUsedButtons)
            {
                GameObject buttonObjectCopy = Instantiate(usedPrefab, transform) as GameObject;

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
}

