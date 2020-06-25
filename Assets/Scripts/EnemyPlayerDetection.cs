using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetection : MonoBehaviour
{
    [SerializeField]LayerMask   visionLayer;

    [SerializeField]GameObject  player;
    [SerializeField]GameObject  self;

    Collider2D playerCol;
    Collider2D enemyCol;
    readonly EnemyWalk hunt;



    private void Start()
    {
        playerCol = player.GetComponent<Collider2D>();
        enemyCol = self.GetComponent<Collider2D>();
    }
    void Update()
    {
        Vector2 colCenter = playerCol.bounds.center;
        Vector2 selfCenter = enemyCol.bounds.center;
        //Vector2 playerPosition = colCenter;
        //Vector2 wDPosition = WallDetector.transform.position;
        //Debug.Log(wDPosition);
        Vector2 currentDirection =  colCenter - selfCenter;
        float distance = currentDirection.magnitude;

        //if hits something between the player and the enemy comes true if not comes false
        var hit = Physics2D.Raycast(selfCenter, currentDirection.normalized,distance, visionLayer);

        //if there are no obstacles between the enemy and the player 
        if(hit.collider == null )
        {
            float viewAngle = Vector2.Dot(transform.right, currentDirection.normalized);
            if ((viewAngle > 0 || viewAngle == 0) && distance <= 100)
            {
                Debug.Log("u can see");
            }
            else
                Debug.Log("this CAN´t SEE V2");

        }
    }
}
