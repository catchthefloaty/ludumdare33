﻿using UnityEngine;
using System.Collections;

public class fadeout : MonoBehaviour {
    public float speed;
    float alpha = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (alpha < 1)
        {
            alpha += speed * Time.deltaTime;
            GetComponent<UnityEngine.UI.RawImage>().color = new Color(0, 0, 0, alpha);
        }
        else
        {
            
        }
    }
}
