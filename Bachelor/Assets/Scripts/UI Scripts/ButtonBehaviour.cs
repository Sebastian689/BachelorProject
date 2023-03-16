using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{

	public Button yourButton;
	public GameObject overPanel;
	bool Active = false;
	Image panel;
	

	// Start is called before the first frame update
	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		panel = overPanel.GetComponent<Image>();
		panel.enabled = false;
	}

	void TaskOnClick()
	{
		Debug.Log("You have clicked the button!");

		if (Active)
        {
			Active = false;
			panel.enabled = false;
        }
		else
        {
			Active = true;
			panel.enabled = true;
        }

	}
}
