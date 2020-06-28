using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoThrowDoors : MonoBehaviour
{
    GameObject player;

    Vector2 playerPos;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;
    }
    public void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.name == "Player")
        {
            if(Input.GetKey(KeyCode.W))
            {
                SceneManager.LoadScene("Biblioteca");
            }
        }
    }

}
