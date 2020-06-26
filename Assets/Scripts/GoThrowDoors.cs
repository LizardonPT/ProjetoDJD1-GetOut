using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoThrowDoors : MonoBehaviour
{
    public void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.name == "Player")
        {
            Debug.Log("its touching");
            if(Input.GetKey(KeyCode.W))
            {
                Debug.Log("its working");
                SceneManager.LoadScene("Biblioteca");
            }
            //Debug.Log("its working");
            //SceneManager.LoadScene("Biblioteca");
        }
    }
}
