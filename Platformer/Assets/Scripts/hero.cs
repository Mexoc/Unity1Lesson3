﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero : MonoBehaviour
{
    public float direction;
    public float speed = 3f;
    public int health = 100;
    public Vector3 move;
    public int right = 1;
    private SpriteRenderer flip;
    public GameObject prefFireball;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {        
        flip = gameObject.GetComponent<SpriteRenderer>();
        startPosition = new Vector3(gameObject.transform.position.x+1, gameObject.transform.position.y, 1);
    }

    public void Move()
    {
        transform.position += new Vector3(Time.deltaTime*speed*right, 0);
    }

    public void Shoot()
    {
        GameObject temp = Instantiate(prefFireball, new Vector3(gameObject.transform.position.x+1, gameObject.transform.position.y-1), Quaternion.identity);
        temp.name = "fireball";
        temp.GetComponent<fireball>().direction = (right == 1) ? 1: -1;
    }    

    public void Fall()
    {
        if (gameObject.transform.position.y < -5)
        {
            gameObject.transform.position = startPosition;
            gameObject.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            {
                if (flip.flipX == true) flip.flipX = false;
                if (right < 0) right *= -1;               
                Move();
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))        
        {
            {
                if (flip.flipX == false) flip.flipX = true;
                if (right > 0) right *= -1;
                Move();
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
        Fall();
    }
}