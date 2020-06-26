using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{

    [SerializeField]    float       moveSpeed = 65.0f;
    [SerializeField]    Transform   wallDetector = null;
    [SerializeField]    float       detectionRadius = 3.0f;
    [SerializeField]    LayerMask   wallLayers;
    [SerializeField]    LayerMask   whatIsLadder;
    private             Vector2     currentVelocity;
    private             bool        LaderCheck;
    Animator                        hunt;



    Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(moveSpeed, 0.0f);
        hunt = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Hunt(hunt);
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
        //Hunt(hunt);
        CheckLadders();
        Debug.Log(moveSpeed);

    }

    private void OnDrawGizmos()
    {
        if (wallDetector != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(wallDetector.position, detectionRadius);
        }
    }

    public void Hunt(bool hunt)
    {
        Debug.Log(hunt);
        if (hunt == true)
            moveSpeed = 70;
        else
            moveSpeed = 65;
    }

    void TurnBack()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(0, 180, 0);
    }

    private void CheckLadders()
    {
        float vertDistance = 10.0f;
        float inputVertical;
        float climbingSpeed = 40.0f;
        int gooUp = UnityEngine.Random.Range(0, 1);

        RaycastHit2D hitInfoUp = Physics2D.Raycast(transform.position, Vector2.up, vertDistance, whatIsLadder);

        //Debug.Log(gooUp);
        if (hitInfoUp.collider != null)
        {
            Debug.Log(gooUp); 
            LaderCheck = true;
            if (gooUp == 1)
            {
                inputVertical = Input.GetAxisRaw("Vertical");
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, inputVertical * climbingSpeed);
                rigidBody.gravityScale = 0;

            }
            else
            {
                currentVelocity.y = 0;

            }
        }
        else
        {
            rigidBody.gravityScale = 1;
            LaderCheck = false;

        }
    }
}
