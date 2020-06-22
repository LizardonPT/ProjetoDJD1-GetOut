using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Experimental.Rendering.Universal;

public class LanternLight : MonoBehaviour
{
    public GameObject theObject;
    bool lighton = false;
    Light2D lantern;
    
    
    // Start is called before the first frame update
    void Start()
    {
        theObject = GameObject.Find("LanternLight");
        lantern = theObject.GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Use()
    {
        if (lighton == false)
        {
            lighton = true;
            lantern.intensity = 1;
        }
        else
        {
            lighton = false;
            lantern.intensity = 0;
        }
    }
}
