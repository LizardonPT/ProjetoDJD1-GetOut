using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Porta1back : MonoBehaviour
{
    GameObject player;

    Rigidbody2D playerPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            if (Input.GetKey(KeyCode.W))
            {
                SceneManager.LoadScene("Lvl 1 basement");
                playerPos.transform.position = new Vector2(-217, -66);
                
            }
            //Debug.Log("its working");
            //SceneManager.LoadScene("Biblioteca");
        }
    }
}
