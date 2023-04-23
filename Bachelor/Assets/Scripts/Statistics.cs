using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    public GameManager GM;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(OnClickCounter);
    }

    private void Update()
    {
        if (GM == null)
        {
            GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }
    }

    public void OnClickCounter()
    {
        GM.AddClickCounter();
    }
}
