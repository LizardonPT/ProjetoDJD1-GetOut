using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LighterLight : MonoBehaviour
{
    public GameObject theObject;
    public GameObject defaultOff;
    bool lighton = false;
    Light2D lighter;
    Light2D deflight;

    // Start is called before the first frame update
    void Start()
    {
        theObject = GameObject.Find("LighterLight");
        lighter = theObject.GetComponent<Light2D>();

        defaultOff = GameObject.Find("Default Light");
        deflight = defaultOff.GetComponent<Light2D>();
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
            lighter.enabled = true;
            deflight.enabled = false;
        }
        else
        {
            lighton = false;
            lighter.enabled = false;
            deflight.enabled = true;
        }
    }
}
