using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;
    [Header("GamePlay")] 
    public float speed;

    private Vector2 movement;

    void Start()
    {
        
    }

    
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);  
        
        runAnim();
        HeroDirection();
    }

    private void HeroDirection()
    {
        if (movement.x >= 0)
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
        }
        else if (movement.x <0)
        {
            transform.localScale = new Vector3(-2f, 2f, 2f);
        }
    }

    private void runAnim()
    {
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetBool("isRunning",true);
        }
        else
        {
            animator.SetBool("isRunning",false);
        }
    }
}
