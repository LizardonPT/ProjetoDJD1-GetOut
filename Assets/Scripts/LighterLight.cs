using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LighterLight : MonoBehaviour
{
    public GameObject theObject;
    bool lighton = false;
    Light2D lighter;

    // Start is called before the first frame update
    void Start()
    {
        theObject = GameObject.Find("LighterLight");
        lighter = theObject.GetComponent<Light2D>();
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
        }
        else
        {
            lighton = false;
            lighter.enabled = false;
        }
    }
}
