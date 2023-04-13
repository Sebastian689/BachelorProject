using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBehaviour : MonoBehaviour
{
    public GameManager gm;
    [SerializeField] TMP_Text score;

    public string income;
    public string hold;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        income = gm.scoreText.text;
        hold = score.text;
        score.text = gm.scoreText.text;   
    }
}
