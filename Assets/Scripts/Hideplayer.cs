using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideplayer : MonoBehaviour
{
    GameObject  player;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.name == "Player" && Input.GetKey(KeyCode.W))
        {
            player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.7f);
            player.layer = 10;
        }

        else if (collider.name == "Player" && Input.GetKey(KeyCode.S))
        {
            player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
            player.layer = 0;
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
        player.layer = 0;
    }
}
