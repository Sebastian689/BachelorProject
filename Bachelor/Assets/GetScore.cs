using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetScore : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        gameObject.GetComponent<TMP_Text>().text = GameObject.FindGameObjectWithTag("Accumulate").GetComponent<Accumulate>().score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
