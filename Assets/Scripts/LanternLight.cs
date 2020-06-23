using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Experimental.Rendering.Universal;

public class LanternLight : MonoBehaviour
{
    public AudioClip onSound;
    public AudioClip offSound;
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
            //SoundMng.instance.PlaySound(onSound);
            //FindObjectOfType<SoundMng>().PlaySound("LanternON");
            lighton = true;
            lantern.enabled = true;
            SoundMng.instance.PlaySound(onSound);
            //FindObjectOfType<SoundMng>().PlaySound("LightsOn");
        }
        else
        {
            //SoundMng.instance.PlaySound(offSound);
            lighton = false;
            lantern.enabled = false;
            SoundMng.instance.PlaySound(offSound);
        }
    }
}
