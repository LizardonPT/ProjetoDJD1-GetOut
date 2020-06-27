using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Porta1Back : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            Debug.Log("its touching");
            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log("its working");
                //playerPos.transform.position = new Vector2(-150, -86);
                SceneManager.LoadScene("Lvl 1 basement");
            }
            //Debug.Log("its working");
            //SceneManager.LoadScene("Biblioteca");
        }
    }
}
