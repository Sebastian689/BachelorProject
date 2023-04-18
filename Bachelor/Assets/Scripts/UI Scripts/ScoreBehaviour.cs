using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
        if (SceneManager.GetActiveScene().name != "TheEnd")
        {
            income = gm.scoreText.text;
            hold = score.text;
            score.text = gm.scoreText.text;
        }
    }
}
