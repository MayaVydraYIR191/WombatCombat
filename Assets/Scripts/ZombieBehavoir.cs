using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using UnityEngine.UI;

public class ZombieBehavoir : MonoBehaviour
{
    public float speed;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    [SerializeField]
    private float lifeTime = 5;
    
    bool moveingRight;
    private bool facingRight = true;
    private float moveInput;
    private float movInEnemy;
    
    Transform player;
    public float stoppingDistance;
    
    bool angry = false;
    public static int count;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate()
    {
        if (player.localScale.x == -1f)
        {
            Flip();
        }
        else if (player.localScale.x == 1f)
        {
            Flip();
        }
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        

        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
        }
        if (lifeTime <= 0)
        {
           count++;
           Destroy(gameObject);
        }

        else if (angry == true)
        {
            Angry();
        }
    }
        void Flip()
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
            
    }
        

    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}

