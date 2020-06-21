using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetection : MonoBehaviour
{
    public LayerMask        visionLayer;


    public GameObject      Player;

    Rigidbody2D rigidBody;
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
        Vector2 playerPosition = Player.transform.position;
        Vector2 currentDirection = ( playerPosition - rigidBody.position );
        float distance = currentDirection.magnitude;

        //if hits something between the player and the enemy comes true if not comes false
        var hit = Physics2D.Raycast(rigidBody.position, currentDirection.normalized,distance, visionLayer);

        //if hits something between the player and the enemy prints can´t see else checks if the player is in the cone of vision os the enemy
        if(hit == true )
        {
                Debug.Log("this CAN´t SEE");
               
        }
        else
        {
            
            Debug.Log(rigidBody.velocity);
            float viewAngle = Vector2.Dot(rigidBody.velocity.normalized, currentDirection.normalized);
            Debug.Log(viewAngle);
            if (viewAngle > 0 || viewAngle == 0)
            {
                Debug.Log("u can see");
            }
        }
        
    }
}
