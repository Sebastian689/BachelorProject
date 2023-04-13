using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelButton : MonoBehaviour
{
    public GameManager gm;
    public Button thisbutton;
    bool nonAssigned = true;
    // Start is called before the first frame update
    void Update()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        thisbutton = this.GetComponent<Button>();
        if (nonAssigned == true)
        {
            nonAssigned = false;
            Button btn = thisbutton.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        gm.LevelProgress();
    }
}
