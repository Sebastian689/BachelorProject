using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    bool engelsk = true;
    GameObject DanskTutorial;
    GameObject EngelskTutorial;
    GameObject Panel;

    private void Start()
    {

        Panel = GameObject.FindGameObjectWithTag("Panel");
        Panel.SetActive(false);

        EngelskTutorial = GameObject.FindGameObjectWithTag("EngelskTutorial");
        
        DanskTutorial = GameObject.FindGameObjectWithTag("DanskTutorial");
        DanskTutorial.SetActive(false);
    }
    public void OnUnderstoodButton()
    {
        GameObject.FindGameObjectWithTag("StartBlock").GetComponent<Spawnpotato>().Invoke("SpawnPotato",0);
        GameObject.FindGameObjectWithTag("Tutorial").SetActive(false);
    }

    public void OnTranslateButton()
    {
        if (engelsk)
        {
            EngelskTutorial.SetActive(false);
            DanskTutorial.SetActive(true);
            engelsk = false;
        }
        else if (!engelsk)
        {
            DanskTutorial.SetActive(false);
            EngelskTutorial.SetActive(true);
            engelsk = true;
        }
        
    }
}
