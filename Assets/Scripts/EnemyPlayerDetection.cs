using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetection : MonoBehaviour
{
    public LayerMask        visionLayer;


    public GameObject      Player;
    

    void Update()
    {
        Vector2 rBPosition = transform.position;
        Vector2 playerPosition = Player.transform.position;
        Vector2 currentDirection = ( playerPosition - rBPosition );
        var hit = Physics2D.Raycast(rBPosition, currentDirection.normalized,currentDirection.magnitude, visionLayer);
        if(hit == true )
        {
            Debug.Log("this CAN´t SEE");
        }
        else
        {
            Debug.Log("u can see");
        }
        
    }
}
