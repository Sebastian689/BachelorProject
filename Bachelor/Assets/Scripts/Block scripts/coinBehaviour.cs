using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinBehaviour : MonoBehaviour
{
    public GameManager gm;
    public GameObject go;
    private void Start()
    {
        go = GameObject.FindGameObjectWithTag("GameManager");
        gm = go.GetComponent<GameManager>();
    }

    public void COIN()
    {
      
            gm.coinCount++;
            Destroy(this.gameObject);
        

    }
}
