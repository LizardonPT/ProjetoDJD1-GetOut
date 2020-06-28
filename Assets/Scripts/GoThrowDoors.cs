using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoThrowDoors : MonoBehaviour
{
    GameObject player;

    //Rigidbody2D playerPos;

    Vector2 playerPos;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;//player.GetComponent<Rigidbody2D>();
    }
    public void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.name == "Player")
        {
            if(Input.GetKey(KeyCode.W))
            {
                //playerPos.transform.position = new Vector2(-150, -86);
                SceneManager.LoadScene("Biblioteca");
            }
            //Debug.Log("its working");
            //SceneManager.LoadScene("Biblioteca");
        }
    }

}
