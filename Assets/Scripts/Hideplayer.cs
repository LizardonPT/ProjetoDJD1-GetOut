using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideplayer : MonoBehaviour
{
    SpriteRenderer  player;
    GameObject      playerLayer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        playerLayer = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log("help");
                player.color = new Color(1, 1, 1, 0.8f);
                playerLayer.layer = 10; 

            }
        }
    }
}
