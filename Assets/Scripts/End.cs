using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    GameObject player;
    GameObject inventory;

    Vector2 playerPos;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;
        inventory = GameObject.Find("Canvas");
    }

    void Update()
    {

    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            if (Input.GetKey(KeyCode.W))
            {
                SceneManager.LoadScene("Win End");
                Destroy(inventory);
            }
        }
    }
}
