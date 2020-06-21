using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{

    [SerializeField] float      moveSpeed = 65.0f;
    [SerializeField] Transform  wallDetector = null;
    [SerializeField] float      detectionRadius = 3.0f;
    [SerializeField] LayerMask  wallLayers;

    
    Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(moveSpeed, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 currentVelocity = rigidBody.velocity;

        currentVelocity.x = moveSpeed;

        rigidBody.velocity = currentVelocity;
        if(wallDetector)
        {
            Collider2D wallCollision = Physics2D.OverlapCircle(wallDetector.position, detectionRadius, wallLayers);

            bool onWall = wallCollision != null;
            
            if(onWall)
            {
                TurnBack();
            }

            currentVelocity.x = transform.right.x * moveSpeed;

            rigidBody.velocity = currentVelocity;
        }

    }

    private void OnDrawGizmos()
    {
        if (wallDetector != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(wallDetector.position, detectionRadius);
        }
    }


    void TurnBack()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(0, 180, 0);
    }
}
