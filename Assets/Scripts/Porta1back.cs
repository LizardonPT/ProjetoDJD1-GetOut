﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Porta1Back : MonoBehaviour
{
    GameObject player;

    public AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            if (Input.GetKey(KeyCode.W))
            {
                SoundMng.instance.PlaySound(sound);
                SceneManager.LoadScene("Lvl 1 basement");
            }
        }
    }
}
