using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField]   float       moveSpeed = 65.0f;
    [SerializeField]    Transform   wallDetector = null;
    [SerializeField]    float       detectionRadius = 3.0f;
    [SerializeField]    LayerMask   wallLayers;
    [SerializeField]    LayerMask   whatIsLadder;
    GameObject                      player;
    [SerializeField]    LayerMask   visionLayer;
    private             Vector2     currentVelocity;
    private             bool        LaderCheck;
    Animator                        hunt;
    AudioSource                      huntSound;



    Collider2D enemyCol;
    Collider2D playerCol;
    Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCol = player.GetComponent<Collider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(moveSpeed, 0.0f);
        enemyCol = GetComponent<Collider2D>();
        hunt = GetComponent<Animator>();
        huntSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Hunt(hunt);
        Vector2 currentVelocity = rigidBody.velocity;
        Vector2 colCenter = playerCol.bounds.center;
        Vector2 selfCenter = enemyCol.bounds.center;
        Vector2 currentDirection = colCenter - selfCenter;
        float distance = currentDirection.magnitude;

        currentVelocity.x = moveSpeed;

        rigidBody.velocity = currentVelocity;
        Checkplayer(selfCenter, currentDirection, distance, visionLayer);

        if (wallDetector)
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
        CheckLadders();

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
        if (hunt == true)
            moveSpeed = 80;
        else
            moveSpeed = 65;
    }

    void TurnBack()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(0, 180, 0);
    }

    void Checkplayer(Vector2 selfCenter, Vector2 currentDirection, float distance, LayerMask visionLayer)
    {
        if(player.layer == 8)
        {
            var hit = Physics2D.Raycast(selfCenter, currentDirection.normalized, distance, visionLayer);
            if (hit.collider == null)
            {
                float viewAngle = Vector2.Dot(transform.right, currentDirection.normalized);

                if ((viewAngle > 0 || viewAngle == 0) && distance <= 100)
                {
                    hunt.SetBool("Hunt", true);
                    Hunt(true);
                   

                }
                else
                {
                    hunt.SetBool("Hunt", false);
                    Hunt(false);


                }

            }
            else
            {
                hunt.SetBool("Hunt", false);
                Hunt(false);
            }

        }
        
    }

    private void CheckLadders()
    {
        float vertDistance = 10.0f;
        float inputVertical;
        float climbingSpeed = 40.0f;
        int gooUp = UnityEngine.Random.Range(0, 1);

        RaycastHit2D hitInfoUp = Physics2D.Raycast(transform.position, Vector2.up, vertDistance, whatIsLadder);

        Debug.Log("stop1");
        if (hitInfoUp.collider != null)
        {
            Debug.Log("stop2");
            Debug.Log(gooUp); 
            LaderCheck = true;
            if (gooUp == 1)
            {
                Debug.Log("stop3");
                inputVertical = Input.GetAxisRaw("Vertical");
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, inputVertical * climbingSpeed);
                rigidBody.gravityScale = 0;

            }
            else
            {
                Debug.Log("stop4");
                currentVelocity.y = 0;

            }
        }
        else
        {
            Debug.Log("stop5");
            rigidBody.gravityScale = 1;
            LaderCheck = false;

        }


    }
    public void playHuntSound()
    {
        if (!huntSound.isPlaying)
            huntSound.Play();

    }
}
