using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LighterLight : MonoBehaviour
{
    public AudioClip onSound;
    public AudioClip offSound;
    public GameObject theObject;
    public GameObject defaultOff;
    public float lifeTime = 180.0f;
    public float currentTime;
    bool lighton = false;
    Light2D lighter;
    Light2D deflight;

    // Start is called before the first frame update
    public void Start()
    {
        theObject = GameObject.Find("LighterLight");
        lighter = theObject.GetComponent<Light2D>();

        defaultOff = GameObject.Find("Default Light");
        deflight = defaultOff.GetComponent<Light2D>();

        currentTime = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (lighton == true)
        {
            currentTime = lifeTime -= 1 * Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = 0;
                lighter.enabled = false;
                deflight.enabled = true;
                Destroy(gameObject);
            }
        }
    }

    public void Use()
    {
        if (lighton == false)
        {
            lighton = true;
            lighter.enabled = true;
            deflight.enabled = false;
            SoundMng.instance.PlaySound(onSound, 0.5f);
        }
        else
        {
            lighton = false;
            lighter.enabled = false;
            deflight.enabled = true;
            SoundMng.instance.PlaySound(offSound, 0.5f);
        }
    }
}
