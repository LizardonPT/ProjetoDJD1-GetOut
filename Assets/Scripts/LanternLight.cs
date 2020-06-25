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
    public float lifeTime = 300.0f;
    public float currentTime;
    GameObject pilha;
    bool lighton = false;
    Light2D lantern;
    
    
    // Start is called before the first frame update
    void Start()
    {
        theObject = GameObject.Find("LanternLight");
        lantern = theObject.GetComponent<Light2D>();

        currentTime = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        pilha = GameObject.FindWithTag("Pilha");
        if (lighton == true)
        {
            currentTime = lifeTime -= 1 * Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = 0;
                lantern.enabled = false;
                Destroy(pilha);
            }
        }
    }

    public void Use()
    {
        if (pilha == true)
        {
            if (lighton == false)
            {
                lighton = true;
                lantern.enabled = true;
                SoundMng.instance.PlaySound(onSound);
            }
            else
            {
                lighton = false;
                lantern.enabled = false;
                SoundMng.instance.PlaySound(offSound);
            }
        }
    }
}
