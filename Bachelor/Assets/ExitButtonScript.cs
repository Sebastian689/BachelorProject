using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButtonScript : MonoBehaviour
{
    public Button myButton;

    public Button exitButton;

    public Button closeWindowButton;

    public GameObject exitPrompt;
    // Start is called before the first frame update
    void Start()
    {
        myButton = gameObject.GetComponent<Button>();
        exitButton.onClick.AddListener(Exit);
        closeWindowButton.onClick.AddListener(CloseWindow);
        myButton.onClick.AddListener(OpenWindow);
        exitPrompt.SetActive(false);
    }

    void Exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }

    void CloseWindow()
    {
        Debug.Log("Window Closed");
        exitPrompt.SetActive(false);
    }
    
    void OpenWindow()
    {
        Debug.Log("Window Opened");
        exitPrompt.SetActive(true);
    }
}
