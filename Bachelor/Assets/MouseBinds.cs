using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBinds : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}
