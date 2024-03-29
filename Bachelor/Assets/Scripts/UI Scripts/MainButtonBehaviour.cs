using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainButtonBehaviour : MonoBehaviour
{
	public Button yourButton;
	public GameObject overPanel;
	public GameObject adaptivePanel;
	public GameObject recommededPanel;
	public bool Active = false;
	GameObject panel;
	
	
	public MainButtonBehaviour[] panelHolder;

	// Start is called before the first frame update
	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		panel = overPanel;
		panel.SetActive(false);
		adaptivePanel = GameObject.FindGameObjectWithTag("AdpPanel");
		recommededPanel = GameObject.FindGameObjectWithTag("Recommended Panel");
	}

    private void Update()
    {
        if(Active == false)
        {
			panel.SetActive(false);
		}
		else if(Active == true)
        {
			panel.SetActive(true);
		}
    }
    void TaskOnClick()
	{
		Debug.Log("You have clicked the button!");

		if (Active)
        {
			Active = false;
        }
		else
        {
			
			Active = true;
			adaptivePanel.SetActive(false);
			recommededPanel.SetActive(false);
			foreach(MainButtonBehaviour panel in panelHolder)
            {
				
				panel.Active = false;
            }
			
        }

	}
}
