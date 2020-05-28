using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetection : MonoBehaviour
{
    public LayerMask        visionLayer;


    public GameObject      Player;
    
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Vector2 rBPosition = transform.position;
        Vector2 playerPosition = Player.transform.position;
        Vector2 currentDirection = ( playerPosition - rBPosition );
        RaycastHit2D hit = Physics2D.Raycast(rBPosition, currentDirection.normalized,currentDirection.magnitude, visionLayer);
        if(hit == null )
        {
            Debug.Log("this is hitting something");
        }
        else
        {
            Debug.Log("GOD BLESS U");
        }
        
    }
}
