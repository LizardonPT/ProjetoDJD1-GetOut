﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortaSala : MonoBehaviour
{
    GameObject player;

    Vector2 playerPos;

    public AudioClip sound;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;
    }

    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.name == "Player")
        {
            if(Input.GetKey(KeyCode.W))
            {
                SoundMng.instance.PlaySound(sound);
                SceneManager.LoadScene("Sala de Estar");
            }
        }
    }
}
