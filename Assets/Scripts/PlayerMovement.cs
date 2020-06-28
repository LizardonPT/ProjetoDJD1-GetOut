﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 50.0f;
    public float climbingSpeed = 40.0f;
    public float vertDistance = 10.0f;
    public LayerMask whatIsLadder;
    private float inputVertical;
    private bool LaderCheck;
    public AudioClip moveSound;

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

        anim.SetFloat("AbsVely", (currentVelocity.y));

        anim.SetBool("LaderCheck", LaderCheck);

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
            maxSpeed = 90.0f;
        }
        else
        {
            maxSpeed = 50.0f;
        }

        //To climb the ladder

        RaycastHit2D hitInfoUp = Physics2D.Raycast(transform.position, Vector2.up, vertDistance, whatIsLadder);

        if(hitInfoUp.collider != null)
        {
            LaderCheck = true;
            if (Input.GetKey(KeyCode.W))
            {
                inputVertical = Input.GetAxisRaw("Vertical");
                rb.velocity = new Vector2(rb.velocity.x, inputVertical * climbingSpeed);
                rb.gravityScale = 0;

            }
            else
            {
                currentVelocity.y = 0;
                
            }
        }
        else
        {
            rb.gravityScale = 1;
            LaderCheck = false;

        }

        RaycastHit2D hitInfoDown = Physics2D.Raycast(transform.position, Vector2.down, vertDistance, whatIsLadder);

        if (hitInfoDown.collider != null)
        {
            LaderCheck = true;
            if (Input.GetKey(KeyCode.S))
            {
                inputVertical = Input.GetAxisRaw("Vertical");
                rb.velocity = new Vector2(rb.velocity.x, inputVertical * climbingSpeed);
                rb.gravityScale = 0;



            }
            else
            {
                currentVelocity.y = 0;
                
            }
            
        }
        else
        {
            rb.gravityScale = 1;
            LaderCheck = false;
        }


    }

    public void MoveSteps()
    {
        if(moveSound)
        {
            SoundMng.instance.PlaySound(moveSound, UnityEngine.Random.Range(0.25f,0.3f));
        }
    }
}
