using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButton : MonoBehaviour
{
    public Spawnpotato SP;
    public GameObject GO;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        GO = GameObject.FindWithTag("StartBlock");
        SP = GO.GetComponent<Spawnpotato>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        SP.SpawnPotato();
    }
}
