using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetection : MonoBehaviour
{
    [SerializeField]LayerMask   visionLayer;

    GameObject                  player;
    [SerializeField]GameObject  self;
    EnemyWalk help;

    Collider2D  playerCol;
    Collider2D  enemyCol;
    Animator    hunt;




    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCol = player.GetComponent<Collider2D>();
        enemyCol = self.GetComponent<Collider2D>();
        hunt = GetComponent<Animator>();
        help = self.GetComponent<EnemyWalk>();
    }
    void Update()
    {
        Vector2 colCenter = playerCol.bounds.center;
        Vector2 selfCenter = enemyCol.bounds.center;
        Vector2 currentDirection =  colCenter - selfCenter;
        float distance = currentDirection.magnitude;

        //if hits something between the player and the enemy comes true if not comes false
        var hit = Physics2D.Raycast(selfCenter, currentDirection.normalized,distance, visionLayer);

        //if there are no obstacles between the enemy and the player 
        if(hit.collider == null )
        {
            //Debug.Log(hunt.GetBool("Hunt"));
            float viewAngle = Vector2.Dot(transform.right, currentDirection.normalized);
            if ((viewAngle > 0 || viewAngle == 0) && distance <= 100)
            {
                hunt.SetBool("Hunt", true);
                help.Hunt(hunt);
            
            }
            else
            {
                //Debug.Log("help");
                hunt.SetBool("Hunt", false);

                help.Hunt(hunt);
                //Debug.Log(hunt.GetBool("Hunt"));
            }

        }
    }
}
