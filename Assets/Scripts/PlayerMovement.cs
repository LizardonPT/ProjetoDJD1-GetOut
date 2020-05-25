using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 50.0f;

    Rigidbody2D rb;

    Animator anim; 
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");

        Vector2 currentVelocity = rb.velocity;

        currentVelocity = new Vector2(maxSpeed * hAxis, currentVelocity.y);

        rb.velocity = currentVelocity;

        anim.SetFloat("AbsVelx", Mathf.Abs(currentVelocity.x));

        //Changes walking/runing directions
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.rotation = Quaternion.identity;
        }

        //Run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            maxSpeed = 80.0f;
        }
        else
        {
            maxSpeed = 50.0f;
        }
    }
}
